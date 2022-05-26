using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.DTOs.UserDTOs;
using SmartWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartWork.Core.Abstractions.Services
{
    public interface IUserService
    {
        //Task<InfoUserDTO> GetUserInfoAsync(string id);
        //Task<InfoUserDTO> GetUserInfoAsync(Expression<Func<TEntity, bool>> expression);
        //Task<IdentityResult> LoginAsync(LoginUserDTO transferObject);
        //Task<IdentityResult> RegisterAsync(RegisterUserDTO transferObject);
        //Task<IdentityResult> UpdateAsync(UpdateUserDTO transferObject);
       

        Task<IEnumerable<User>> GetUsersAsync(Expression<Func<User, bool>> expression);
        Task<InfoUserDTO> GetUserProfileAsync(ClaimsPrincipal user);
        Task<User> GetUserByIdAsync(string id);
        //Task<IEnumerable<Subscribe>> GetUserSubscribesAsync(string id);
        Task<ActionResult<UserDTO>> LoginAsync(LoginUserDTO transferObject);
        Task<IdentityResult> RegisterAsync(RegisterUserDTO transferObject);
        Task<IdentityResult> UpdateAsync(UpdateUserDTO transferObject);
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordDTO transferObject);
        Task<IdentityResult> DeleteAsync(string id);
        Task<ActionResult> Logout();
    }
}
