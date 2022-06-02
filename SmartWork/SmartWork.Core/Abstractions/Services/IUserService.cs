using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.DTOs.UserDTOs;
using SmartWork.Core.Entities;
using SmartWork.Core.Models;
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
       

        Task<List<User>> GetUsersAsync(PageInfo pageInfo);
        Task<InfoUserDTO> GetUserProfileAsync(ClaimsPrincipal user);
        Task<User> GetUserByIdAsync(string id);
        //Task<IEnumerable<Subscribe>> GetUserSubscribesAsync(string id);
        Task<ActionResult<UserDTO>> LoginAsync(LoginUserDTO transferObject);
        Task<ActionResult<UserDTO>> RegisterAsync(RegisterUserDTO transferObject);
        Task<ActionResult<UserDTO>> GetCurrentUserAsync(string email);
        Task<IdentityResult> UpdateAsync(UpdateUserDTO transferObject);
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordDTO transferObject);
        Task<IdentityResult> DeleteAsync(string id);
        Task<ActionResult> Logout();
    }
}
