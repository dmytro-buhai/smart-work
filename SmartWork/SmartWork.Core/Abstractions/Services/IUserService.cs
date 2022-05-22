using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.DTOs.UserDTOs;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartWork.Core.Abstractions.Services
{
    public interface IUserService<TEntity> where TEntity : IdentityUser
    {
        Task<InfoUserDTO> GetUserInfoAsync(string id);
        Task<InfoUserDTO> GetUserInfoAsync(Expression<Func<TEntity, bool>> expression);
        Task<IdentityResult> LoginAsync(LoginUserDTO transferObject);
        Task<IdentityResult> RegisterAsync(RegisterUserDTO transferObject);
        Task<IdentityResult> UpdateAsync(UpdateUserDTO transferObject);
        Task<IActionResult> Logout();
    }
}
