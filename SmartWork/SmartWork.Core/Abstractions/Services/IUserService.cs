using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Entities;
using SmartWork.Core.ViewModels.UserViewModels;
using System;
using System.Threading.Tasks;

namespace SmartWork.Core.Abstractions.Services
{
    public interface IUserService<TUser> where TUser : User
    {
        Task<UserInfoViewModel> GetUserInfoAsync(string id);
        Task<UserInfoViewModel> GetUserInfoAsync(Func<TUser, bool> expression);
        Task<IdentityResult> SignInAsync(SignInViewModel model);
        Task<IdentityResult> SingUpAsync(SignUpViewModel model);
        Task<IdentityResult> UpdateAsync(EditUserViewModel model);
        Task<IActionResult> Logout();
    }
}
