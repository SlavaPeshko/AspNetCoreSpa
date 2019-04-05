using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.Application.ViewModels;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;
using AspNetCoreSpa.Data.Repositories.Contracts;
using AspNetCoreSpa.Data.UoW;
using AspNetCoreSpa.Domain.Enities;
using AspNetCoreSpa.Domain.Enities.Base;
using AspNetCoreSpa.Domain.Models;

namespace AspNetCoreSpa.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IUserRepository _userRepository;

        public UserService(IUnitOfWorks unitOfWorks, IUserRepository userRepository)
        {
            _unitOfWorks = unitOfWorks;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserViewModel>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsersAsync();

            return users.Select(c => c.ToEntity());
        }

        public async Task<CreateUserModel> PostAsync(CreateUserModel createUserModel)
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

            if (user == null)
                return Result.Fail<LogInViewModel>(ErrorCode.UserNotFound, ET.UserNotFound);

            LogInViewModel logInViewModel = new LogInViewModel();
            logInViewModel.Token = "token";
            logInViewModel.RerfreshToken = "rerfreshToken";

            return Result.OK(logInViewModel);
        }
    }
}
