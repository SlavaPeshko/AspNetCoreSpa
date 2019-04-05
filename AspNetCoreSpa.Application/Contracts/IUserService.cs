using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.ViewModels;
using AspNetCoreSpa.Domain.Enities;
using AspNetCoreSpa.Domain.Enities.Base;
using AspNetCoreSpa.Domain.Models;

namespace AspNetCoreSpa.Application.Services.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetUsersAsync();
        Task<CreateUserModel> PostAsync(CreateUserModel userModel);
        void Put(User user);
        
        // TODO SQRS
        Task<Result<LogInViewModel>> LogInAsync(LoginInputModel model);
    }
}
