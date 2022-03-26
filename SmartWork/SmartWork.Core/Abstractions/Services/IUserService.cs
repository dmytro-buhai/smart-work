using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.ViewModels.UserViewModels;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartWork.Core.Abstractions.Services
{
    public interface IUserService<TEntity> where TEntity : IdentityUser
    {
        Task<UserInfoViewModel> GetUserInfoAsync(string id);
        Task<UserInfoViewModel> GetUserInfoAsync(Expression<Func<TEntity, bool>> expression);
        Task<IdentityResult> SignInAsync(SignInViewModel model);
        Task<IdentityResult> SingUpAsync(SignUpViewModel model);
        Task<IdentityResult> UpdateAsync(EditUserViewModel model);
        Task<IActionResult> Logout();
    }
}
