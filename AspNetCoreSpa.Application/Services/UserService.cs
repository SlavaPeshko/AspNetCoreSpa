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

namespace AspNetCoreSpa.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenHelper _jwtTokenHelper;

        public UserService(IUnitOfWorks unitOfWorks,
            IUserRepository userRepository,
            IJwtTokenHelper jwtTokenHelper)
        {
            _unitOfWorks = unitOfWorks;
            _userRepository = userRepository;
            _jwtTokenHelper = jwtTokenHelper;
        }

        public async Task<IEnumerable<UserViewModel>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsersAsync();

            return users.Select(c => c.ToEntity());
        }

        public async Task<CreateUserInputModel> PostAsync(CreateUserInputModel createUserModel)
        {
            var isUniqueUserCode = await _userRepository.IsUniqueUserCodeAsync(createUserModel.UserCode);
            if (isUniqueUserCode)
            {
                //return 
            }

            var user = new User
            {
                // ClientName = createClientModel.ClientName,
                UserCode = createUserModel.UserCode,
                CountryId = createUserModel.CountryId
            };

            await _userRepository.PostAsync(user);
            await _unitOfWorks.CommitAsync();

            return createUserModel;
        }

        public void Put(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<LogInViewModel>> LogInAsync(LoginInputModel model)
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

            //if (user == null)
            //    return Result.Fail<LogInViewModel>(ErrorCode.UserNotFound, ET.UserNotFound);

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
    }
}
