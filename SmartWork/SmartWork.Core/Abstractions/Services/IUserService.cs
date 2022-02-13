using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Entities;
using SmartWork.Core.ViewModels.UserViewModels;
using System;
using System.Threading.Tasks;

namespace SmartWork.Core.Abstractions.Services
{
    public interface IUserService: IService<User>
    {
        Task<UserInfoViewModel> GetUserInfoAsync(int id);
        Task<UserInfoViewModel> GetUserInfoAsync(Func<User, bool> expression);
        Task<IdentityResult> SignInAsync(SignInViewModel model);
        Task<IdentityResult> SingUpAsync(SignUpViewModel model);
        Task<IdentityResult> UpdateAsync(EditUserViewModel model);
        Task<IActionResult> Logout();
    }
}
