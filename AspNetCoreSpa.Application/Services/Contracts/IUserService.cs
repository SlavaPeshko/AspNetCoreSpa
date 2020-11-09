using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Models.Users;
using AspNetCoreSpa.Domain.Entities.Base;

namespace AspNetCoreSpa.Application.Services.Contracts
{
    public interface IUserService : IBaseService
    {
        Task<IEnumerable<UserViewModel>> GetUsersAsync();
        Task<Result<UserViewModel>> CreateUserAsync(CreateUserModel userModel);
        Task<Result> UpdateUserAsync(UpdateUserModel model);
        Task<Result> UpdatePasswordAsync(int id, UpdatePasswordModel model);

        // TODO SQRS
        Task<Result<TokenViewModel>> LogInAsync(LogInModel model);
        Task<Result<bool>> SendEmailConfirmEmailAsync(int userId);
        Task<Result> ConfirmEmailAsync(string token);
        Task<Result<UserViewModel>> GetUserAsync(int id);

        Task<Result> ChangeEmailAsync(int id, ChangeEmailModel model);

        Task<Result> SendSmsCodeAsync(string phoneNumber, string countryCode);

        /// <summary>
        ///     Send email with token when user forgot password
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<Result> SendEmailAsync(string email);

        /// <summary>
        ///     Validate token when user forgot password
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<Result<string>> ValidateTokenAsync(string token);

        /// <summary>
        ///     Reset password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Result> ForgotPasswordAsync(PasswordResetModel model);
    }
}