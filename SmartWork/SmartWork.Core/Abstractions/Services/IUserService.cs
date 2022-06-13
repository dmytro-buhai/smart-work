using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.DTOs.UserDTOs;
using SmartWork.Core.Entities;
using SmartWork.Core.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartWork.Core.Abstractions.Services
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync(PageInfo pageInfo);
        Task<InfoUserDTO> GetUserProfileAsync(ClaimsPrincipal user);
        Task<User> GetUserByIdAsync(string id);
        Task<ActionResult<UserDTO>> LoginAsync(LoginUserDTO transferObject);
        Task<ActionResult<UserDTO>> RegisterAsync(RegisterUserDTO transferObject);
        Task<ActionResult<UserDTO>> GetCurrentUserAsync(string email);
        Task<IdentityResult> UpdateAsync(UpdateUserDTO transferObject);
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordDTO transferObject);
        Task<IdentityResult> DeleteAsync(string id);
        Task<ActionResult> Logout();
    }
}
