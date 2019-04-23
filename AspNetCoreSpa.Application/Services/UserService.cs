﻿using System;
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

namespace AspNetCoreSpa.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenHelper _jwtTokenHelper;
        private readonly IEmailSender _emailSender;

        public UserService(IUnitOfWorks unitOfWorks,
            IUserRepository userRepository,
            IJwtTokenHelper jwtTokenHelper,
            IEmailSender emailSender)
        {
            _unitOfWorks = unitOfWorks;
            _userRepository = userRepository;
            _jwtTokenHelper = jwtTokenHelper;
            _emailSender = emailSender;
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
                Token = await _jwtTokenHelper.GenerateToken(user),
            };

            return Result.OK(logInViewModel);
        }

        public async Task<bool> IsExistEmailAsync(string email)
        {
            bool isExist = await _userRepository.IsExistEmailAsync(email);

            return isExist;
        }

        public async Task<Result<bool>> ConfirmEmailAsync(Guid userId, IUrlHelper url)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                return Result.Fail<bool>(ErrorCode.UserNotFound, ET.UserNotFound);
            }

            var code = "12345";

            var callbackUrl = UrlHelperExtensions.Page(url, "", null, new { userId = user.Id, code });

            var htmlMessage = $"Please confirm your email by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.";

            await _emailSender.SendEmailAsync(user.Email, "Confirm email", htmlMessage);

            return Result.OK(true);
        }
    }
}
