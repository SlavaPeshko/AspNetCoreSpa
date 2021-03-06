﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Helpers;
using AspNetCoreSpa.Application.Models.Users;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.Contracts.QueryRepositories;
using AspNetCoreSpa.Data.Repositories.Contracts;
using AspNetCoreSpa.Data.UoW;
using AspNetCoreSpa.Domain.Entities;
using AspNetCoreSpa.Domain.Entities.Base;
using AspNetCoreSpa.Domain.Entities.Enum;
using AspNetCoreSpa.Domain.Entities.Security;
using AspNetCoreSpa.Infrastructure.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;
using EC = AspNetCoreSpa.Domain.Entities.ErrorCode;

namespace AspNetCoreSpa.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IConfiguration _configuration;
        private readonly IEmailSender _emailSender;
        private readonly GlobalSettings _globalSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtTokenHelper _jwtTokenHelper;
        private readonly ISecurityCodeQueryRepository _securityCodeQueryRepository;
        private readonly ISecurityCodesRepository _securityCodesRepository;
        private readonly ISmsService _smsService;
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IUserContext _userContext;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IUserRepository _userRepository;

        public UserService(IUnitOfWorks unitOfWorks,
            IUserRepository userRepository,
            IUserQueryRepository userQueryRepository,
            IJwtTokenHelper jwtTokenHelper,
            IEmailSender emailSender,
            ISecurityCodesRepository securityCodesRepository,
            IConfiguration configuration,
            GlobalSettings globalSettings,
            IHttpContextAccessor httpContextAccessor,
            IAddressRepository addressRepository,
            ISecurityCodeQueryRepository securityCodeQueryRepository,
            ISmsService smsService,
            IUserContext userContext)
        {
            _unitOfWorks = unitOfWorks;
            _userRepository = userRepository;
            _userQueryRepository = userQueryRepository;
            _jwtTokenHelper = jwtTokenHelper;
            _emailSender = emailSender;
            _securityCodesRepository = securityCodesRepository;
            _configuration = configuration;
            _globalSettings = globalSettings;
            _httpContextAccessor = httpContextAccessor;
            _addressRepository = addressRepository;
            _securityCodeQueryRepository = securityCodeQueryRepository;
            _smsService = smsService;
            _userContext = userContext;
        }

        public async Task<IEnumerable<UserViewModel>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsersAsync();

            return users.Select(c => c.ToViewModel());
        }

        public async Task<Result<UserViewModel>> CreateUserAsync(CreateUserModel model)
        {
            var user = new User();

            if (model.Email.IndexOf("@", StringComparison.Ordinal) > -1)
            {
                var isExistEmail = await _userQueryRepository.IsExistEmailAsync(model.Email);
                if (isExistEmail)
                    return Result.Fail<UserViewModel>(EC.EmailAlreadyExists, ET.EmailAlreadyExists);

                user.Email = model.Email;
            }
            else
            {
                var code = await _securityCodeQueryRepository.GetSecurityCodeAsync((int) ProviderType.Phone,
                    (int) CodeActionType.CreateUserByPhone,
                    model.InternationalPhoneNumber,
                    DateTimeOffset.UtcNow.AddMinutes(-1));

                if (code != model.SecurityCode)
                    return Result.Fail<UserViewModel>(EC.SecurityCodeInvalid, ET.SecurityCodeInvalid);

                user.PhoneNumber = model.InternationalPhoneNumber;
            }

            user.PasswordHash = PasswordHasher.GetHashPassword(model.Password);

            var userRole = new UserRole
            {
                User = user,
                RoleId = UserRoleEnum.User
            };

            user.UserRoles.Add(userRole);

            await _userRepository.PostAsync(user);
            await _unitOfWorks.CommitAsync();

            return Result.OK(user.ToViewModel());
        }

        public async Task<Result> UpdateUserAsync(UpdateUserModel model)
        {
            var user = await _userRepository.GetUserByIdAsync(_userContext.UserId);
            if (user == null)
                return Result.Fail(EC.UserNotFound, ET.UserNotFound);

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.DateOfBirth = model.DateOfBirth;
            user.Gender = (Gender) model.Gender;

            if (user.PhoneNumber != null && user.PhoneNumber != model.Phone)
            {
                user.PhoneNumber = model.Phone;
                user.PhoneNumberConfirmed = false;
            }

            if (model.Address != null && model.Address.Id > 0)
            {
                var address = await _addressRepository.GetAddressByIdAsync(model.Address.Id);
                if (address == null)
                    return Result.Fail(EC.AddressNotFound, ET.AddressNotFound);

                address.Address1 = model.Address.Address1;
                address.Address2 = model.Address.Address2;
                address.City = model.Address.City;
                address.Postcode = model.Address.Postcode;
                address.CountryId = model.Address.CountryId;

                _addressRepository.Put(address);
            }
            else if (model.Address != null && model.Address.Id == 0)
            {
                var address = new Address
                {
                    Address1 = model.Address.Address1,
                    Address2 = model.Address.Address2,
                    City = model.Address.City,
                    Postcode = model.Address.Postcode,
                    CountryId = model.Address.CountryId
                };

                var userAddress = new UserAddress
                {
                    Address = address,
                    User = user,
                    AddressTypeId = AddressTypeEnum.Home
                };

                user.UserAddresses.Add(userAddress);
            }

            _userRepository.Put(user);
            await _unitOfWorks.CommitAsync();

            return Result.Ok();
        }

        public async Task<Result> UpdatePasswordAsync(int id, UpdatePasswordModel model)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
                return Result.Fail(EC.UserNotFound, ET.UserNotFound);

            var verifyPassword = PasswordHasher.VerifyHashedPassword(user.PasswordHash, model.OldPassword);
            if (!verifyPassword) return Result.Fail(EC.PasswordInvalid, ET.PasswordInvalid);

            user.PasswordHash = PasswordHasher.GetHashPassword(model.NewPassword);
            _userRepository.Put(user);
            await _unitOfWorks.CommitAsync();

            return Result.Ok();
        }

        public async Task<Result<TokenViewModel>> LogInAsync(LogInModel model)
        {
            User user;
            if (model.Email.IndexOf("@", StringComparison.Ordinal) > -1)
                user = await _userRepository.GetUserByEmailAsync(model.Email);
            else
                user = await _userRepository.GetUserByPhoneAsync(model.Email);

            if (user == null)
                return Result.Fail<TokenViewModel>(EC.UserNotFound, ET.UserNotFound);

            if (user.LockoutEnd.HasValue && user.LockoutEnd >= DateTimeOffset.UtcNow)
                return Result.Fail<TokenViewModel>(EC.AccessFailedCount, ET.AccessFailedCount);

            var verifyPassword = PasswordHasher.VerifyHashedPassword(user.PasswordHash, model.Password);
            if (!verifyPassword)
            {
                await SetLockoutUser(user);
                return Result.Fail<TokenViewModel>(EC.PasswordInvalid, ET.PasswordInvalid);
            }

            var refreshToken = _jwtTokenHelper.GenerateRefreshToken(user);

            var logInViewModel = new TokenViewModel
            {
                RefreshToken = refreshToken,
                AccessToken = new AccessToken
                {
                    Token = _jwtTokenHelper.GenerateToken(user),
                    ExpiresIn = _globalSettings.Jwt.Expiration
                }
            };

            user.RefreshToken = refreshToken;
            _userRepository.Put(user);
            await _unitOfWorks.CommitAsync();

            return Result.OK(logInViewModel);
        }

        public async Task<Result<bool>> SendEmailConfirmEmailAsync(int userId)
        {
            var user = await _userQueryRepository.GetUserByIdAsync(userId);
            if (user == null)
                return Result.Fail<bool>(EC.UserNotFound, ET.UserNotFound);

            if (user.EmailConfirmed)
                return Result.Fail<bool>(EC.EmailAlreadyConfirmed, ET.EmailAlreadyConfirmed);

            var securityCode = SecurityCode.Create(ProviderType.Email, user.Email, CodeActionType.ConfirmEmail);
            await _securityCodesRepository.CreateAsync(securityCode);

            var token = _jwtTokenHelper.GenerateTokenWithSecurityCode(userId.ToString(), user.Email, securityCode.Code);

            var url = $"{_configuration["UiBaseUrl"]}confirm-email?token={token}";

            var htmlMessage =
                $"Please confirm your email by <a href=\"{HtmlEncoder.Default.Encode(url)}\">clicking here</a>.";

            await _emailSender.SendEmailAsync(user.Email, "Confirm email", htmlMessage);

            await _unitOfWorks.CommitAsync();
            return Result.OK(true);
        }

        public async Task<Result> SendEmailAsync(string email)
        {
            var user = await _userQueryRepository.GetUserByEmailAsync(email);
            if (user == null)
                return Result.Fail<bool>(EC.EmailNotFound, ET.EmailNotFound);

            var securityCode = SecurityCode.Create(ProviderType.Email, email, CodeActionType.ForgotPasswordByEmail);
            await _securityCodesRepository.CreateAsync(securityCode);

            var token = _jwtTokenHelper.GenerateTokenWithSecurityCode($"{user.Id}", email, securityCode.Code);

            var url = $"{_configuration["UiBaseUrl"]}resetpassword?token={token}";
            var htmlMessage =
                $"To reset your password, just click the link below: <a href=\"{HtmlEncoder.Default.Encode(url)}\">clicking here</a>.";

            try
            {
                await _emailSender.SendEmailAsync(email, "Reset your email", htmlMessage);
            }
            catch (Exception e)
            {
                return Result.Fail<bool>(EC.EmailFailedSend, ET.EmailFailedSend);
            }

            await _unitOfWorks.CommitAsync();
            return Result.Ok();
        }

        public async Task<Result<string>> ValidateTokenAsync(string token)
        {
            if (string.IsNullOrEmpty(token))
                return Result.Fail<string>(EC.TokenInvalid, ET.TokenInvalid);

            var model = _jwtTokenHelper.DecodeToken<EmailTokenModel>(token);
            var code = await _securityCodeQueryRepository.GetSecurityCodeAsync((int) ProviderType.Email,
                (int) CodeActionType.ForgotPasswordByEmail, model.Email);

            if (code != model.Code)
                return Result.Fail<string>(EC.TokenInvalid, ET.TokenInvalid);

            return Result.OK(model.Email);
        }

        public async Task<Result> ForgotPasswordAsync(PasswordResetModel model)
        {
            var user = await _userRepository.GetUserByEmailAsync(model.Email);
            if (user == null)
                return Result.Fail(EC.UserNotFound, ET.UserNotFound);

            user.PasswordHash = PasswordHasher.GetHashPassword(model.Password);
            _userRepository.Put(user);
            await _unitOfWorks.CommitAsync();

            return Result.Ok();
        }

        public async Task<Result> ConfirmEmailAsync(string token)
        {
            if (string.IsNullOrEmpty(token))
                return Result.Fail(EC.TokenInvalid, ET.TokenInvalid);

            var model = _jwtTokenHelper.DecodeToken<EmailTokenModel>(token);

            var codes = await _securityCodesRepository.GetSecurityCodesAsync(model.Email, ProviderType.Email,
                CodeActionType.ConfirmEmail);

            if (codes != null && codes.Any())
                _securityCodesRepository.Delete(codes);
            else
                return Result.Fail(EC.TokenInvalid, ET.TokenInvalid);

            var user = await _userRepository.GetUserByIdAsync(model.Id);
            user.EmailConfirmed = true;

            _userRepository.Put(user);
            await _unitOfWorks.CommitAsync();

            return Result.OK(user);
        }

        public async Task<Result<UserViewModel>> GetUserAsync(int userId)
        {
            var user = await _userQueryRepository.GetUserByIdAsync(userId);
            if (user == null)
                return Result.Fail<UserViewModel>(EC.UserNotFound, ET.UserNotFound);

            var viewModel = user.ToViewModel();

            if (viewModel.Image == null)
                return Result.OK(viewModel);

            // var url = new StringBuilder();
            // url.Append(_httpContextAccessor.HttpContext?.Request?.Scheme);
            // url.Append("://");
            // url.Append(_httpContextAccessor.HttpContext?.Request?.Host.Value);
            // url.Append("/");
            // url.Append(viewModel.Image.Path.Replace(@"\", "/"));

            viewModel.Image.Url = $"{_globalSettings.AzureStorageConnection.BlobEndpoint}{user.ImageDto.Path}";

            return Result.OK(viewModel);
        }

        public async Task<Result> ChangeEmailAsync(int id, ChangeEmailModel model)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
                return Result.Fail(EC.UserNotFound, ET.UserNotFound);

            user.Email = model.NewEmail;
            user.EmailConfirmed = false;

            _userRepository.Put(user);
            await _unitOfWorks.CommitAsync();

            return Result.Ok();
        }

        public async Task<Result> SendSmsCodeAsync(string phoneNumber, string countryCode)
        {
            var isExist = await _userQueryRepository.IsExistPhoneAsync(phoneNumber);
            if (!isExist)
                return Result.Fail(EC.PhoneNotFound, ET.PhoneNotFound);

            var code = SecurityCode.Create(ProviderType.Phone, phoneNumber, CodeActionType.ForgotPasswordByPhone);

            await _securityCodesRepository.CreateAsync(code);
            await _unitOfWorks.CommitAsync();

            var smsSender = new SmsSender(_globalSettings);
            var result = await smsSender.SendSmsAsync(phoneNumber, $"{code.Code} is your verification code.");
            if (result == null)
                return Result.Fail(EC.SmsServiceFailed, ET.SmsServiceFailed);

            return Result.Ok();
        }

        private async Task SetLockoutUser(User user)
        {
            if (user.AccessFailedCount >= _globalSettings.Configurations.AccessFailedCount)
            {
                user.LockoutEnd = DateTimeOffset.UtcNow.AddMinutes(_globalSettings.Configurations.AccessFailedCount);
                user.AccessFailedCount = 0;
            }
            else
            {
                user.AccessFailedCount = ++user.AccessFailedCount;
            }

            _userRepository.Put(user);

            await _unitOfWorks.CommitAsync();
        }
    }
}