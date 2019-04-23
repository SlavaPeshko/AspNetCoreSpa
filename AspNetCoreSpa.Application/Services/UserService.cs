using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Services.Contracts;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;
using AspNetCoreSpa.Data.Repositories.Contracts;
using AspNetCoreSpa.Data.UoW;
using AspNetCoreSpa.Domain.Enities;
using AspNetCoreSpa.Domain.Enities.Base;
using AspNetCoreSpa.Application.Models;
using AspNetCoreSpa.Application.Helpers;
using AspNetCoreSpa.Domain.Enities.Enum;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Text.Encodings.Web;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using AspNetCoreSpa.Domain.Enities.Security;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreSpa.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenHelper _jwtTokenHelper;
        private readonly IEmailSender _emailSender;
        private readonly ISecurityCodesRepository _securityCodesRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUnitOfWorks unitOfWorks,
            IUserRepository userRepository,
            IJwtTokenHelper jwtTokenHelper,
            IEmailSender emailSender,
            ISecurityCodesRepository securityCodesRepository,
            IConfiguration configuration)
        {
            _unitOfWorks = unitOfWorks;
            _userRepository = userRepository;
            _jwtTokenHelper = jwtTokenHelper;
            _emailSender = emailSender;
            _securityCodesRepository = securityCodesRepository;
            _configuration = configuration;
        }

        public async Task<IEnumerable<UserViewModel>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsersAsync();

            return users.Select(c => c.ToEntity());
        }

        public async Task<Result<UserViewModel>> CreateUserAsync(CreateUserInputModel model)
        {
            User user = new User();

            if(model.EmailOrPhone.IndexOf("@") > -1)
            {
                var isExistEmail = await _userRepository.IsExistEmailAsync(model.EmailOrPhone);
                if (isExistEmail)
                    return Result.Fail<UserViewModel>(ErrorCode.EmailAlreadyExists, ET.EmailAlreadyExists);

                user.Email = model.EmailOrPhone;
            }
            else
            {
                user.PhoneNumber = model.EmailOrPhone;
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.DateOfBirth = model.DateOfBirth;
            user.Gender = Enum.Parse<Gender>(model.Gender);
            user.PasswordHash = PasswordHasher.GetHashPassword(model.Password);

            var userRole = new UserRole
            {
                User = user,
                Role = new Role
                {
                    Name = RoleEnum.User
                }
            };

            user.UserRoles.Add(userRole);

            await _userRepository.PostAsync(user);
            await _unitOfWorks.CommitAsync();

            return Result.OK(user.ToEntity());
        }

        public void Put(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<LogInViewModel>> LogInAsync(LogInInputModel model)
        {
            User user = null;
            if(model.EmailOrPhone.IndexOf("@") > -1)
            {
                user = await _userRepository.GetUserByEmailAsync(model.EmailOrPhone);
            }
            else
            {
                user = await _userRepository.GetUserByPhoneAsync(model.EmailOrPhone);
            }

            if (user == null)
                return Result.Fail<LogInViewModel>(ErrorCode.UserNotFound, ET.UserNotFound);

            var verifyPassword = PasswordHasher.VerifyHashedPassword(user.PasswordHash, model.Password);
            if (!verifyPassword)
                return Result.Fail<LogInViewModel>(ErrorCode.PasswordInvalid, ET.PasswordInvalid);

            var logInViewModel = new LogInViewModel
            {
                Token = await _jwtTokenHelper.GenerateTokenAsync(user),
            };

            return Result.OK(logInViewModel);
        }

        public async Task<bool> IsExistEmailAsync(string email)
        {
            bool isExist = await _userRepository.IsExistEmailAsync(email);

            return isExist;
        }

        public async Task<Result<bool>> SendEmailConfirmEmailAsync(Guid userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                return Result.Fail<bool>(ErrorCode.UserNotFound, ET.UserNotFound);
            }

            if (user.EmailConfirmed)
            {
                // TODO: error description
                return Result.Fail<bool>(ErrorCode.EmailAlreadyConfirmed, "");
            }

            var codeActionType = CodeActionType.ConfirmEmail;
            var providerType = ProviderType.Email;

            var securityCode = SecurityCode.Create(providerType, user.Email, codeActionType);
            // await _securityCodesRepository.CreateAsync(securityCode);

            var token = _jwtTokenHelper.GenerateTokenWithSecurityCode(user, codeActionType, providerType, securityCode.Code);

            var url = $"{_configuration["UiBaseUrl"]}confirm-email?token={token}";

            var htmlMessage = $"Please confirm your email by <a href='{HtmlEncoder.Default.Encode(url)}'>clicking here</a>.";

            await _emailSender.SendEmailAsync(user.Email, "Confirm email", htmlMessage);

            return Result.OK(true);
        }

        public async Task<Result> ConfirmEmailAsync(string token)
        {
            var res = _jwtTokenHelper.DecodeToken(token);

            throw new NotImplementedException();
        }
    }
}
