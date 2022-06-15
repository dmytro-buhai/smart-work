using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.UserDTOs;
using SmartWork.Core.Entities;
using SmartWork.Core.Models;
using SmartWork.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartWork.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User> _repository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly TokenService _tokenService;
        private readonly ILogger<UserService> _logger;
        //private readonly ISubscribeService _subscribeService;

        public UserService(IUserRepository<User> repository,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            TokenService tokenService,
            ILogger<UserService> logger)
        {
            _repository = repository;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _logger = logger;
            //_subscribeService = subscribeService;
        }

        /// <summary>
        /// Get Users
        /// </summary>
        /// <param name="specification"></param>
        /// <returns></returns>
        public Task<List<User>> GetUsersAsync(PageInfo pageInfo)
        {
            return _repository.GetAsync(pageInfo);
        }

        /// <summary>
        /// GET UserRoles
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetUserRolesAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return await _userManager.GetRolesAsync(user);
        }

        /// <summary>
        /// GET Logged In User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<User> GetUserAsync(ClaimsPrincipal user)
        {
            return _userManager.FindByIdAsync(user.Claims.First(c => c.Type == "UserId").Value);
        }

        /// <summary>
        /// GET Logged In UserProfile
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<InfoUserDTO> GetUserProfileAsync(ClaimsPrincipal user)
        {
            string userId = user.Claims.First(c => c.Type == "UserId").Value;
            var currentUser = await _userManager.FindByIdAsync(userId);

            return JsonConvert.DeserializeObject<InfoUserDTO>(
                JsonConvert.SerializeObject(currentUser));
        }

        /// <summary>
        /// GET UserById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<User> GetUserByIdAsync(string id)
        {
            return _repository.FindAsync(id);
        }

        /// <summary>
        /// ADD UserRole
        /// </summary>
        /// <param name="user"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public Task<IdentityResult> AddUserRoleAsync(User user, string role)
        {
            return _userManager.AddToRoleAsync(user, role);
        }

        /// <summary>
        /// ADD UserRoles
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public Task<IdentityResult> AddUserRolesAsync(User user, IEnumerable<string> roles)
        {
            return _userManager.AddToRolesAsync(user, roles);
        }

        /// <summary>
        /// Sign in User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ActionResult<UserDTO>> LoginAsync(LoginUserDTO transferObject)
        {
            var user = await _userManager.FindByEmailAsync(transferObject.Email);

            if (user == null)
            {
                return new UnauthorizedResult();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, transferObject.Password, false);

            if (result.Succeeded)
            {
                return CreateUserObject(user);
            }

            return new UnauthorizedResult();
        }

        /// <summary>
        /// Sign up User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ActionResult<UserDTO>> RegisterAsync(RegisterUserDTO transferObject)
        {
            const string userRole = "user";

            var user = new User
            {
                Email = transferObject.Email,
                UserName = transferObject.Username,
                DisplayName = transferObject.DisplayName,
                PhoneNumber = transferObject.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(user, transferObject.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, userRole);
                return CreateUserObject(user);
            }

            return new BadRequestObjectResult("An error during user registration");
        }

        public async Task<ActionResult<UserDTO>> GetCurrentUserAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return CreateUserObject(user);
        }

        private UserDTO CreateUserObject(User user)
        {
            return new UserDTO
            {
                Email = user.Email,
                DisplayName = user.DisplayName,
                Username = user.UserName,
                Token = _tokenService.CreateToken(user),
                PhoneNumber = user.PhoneNumber
            };
        }

        /// <summary>
        /// Log out User
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return new OkResult();
            }
            catch (Exception ex)
            {
                _logger.LogError("UserService/LogoutAsync\n" + ex.Message);
                return new BadRequestResult();
            }
        }

        /// <summary>
        /// Update User 
        /// </summary>
        /// <param name="transferObject"></param>
        /// <returns></returns>
        public async Task<IdentityResult> UpdateAsync(UpdateUserDTO transferObject)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == transferObject.Username);

            user.Email = transferObject.Email;
            user.UserName = transferObject.Username;
            user.DisplayName = transferObject.DisplayName;
            user.PhoneNumber = transferObject.PhoneNumber;

            return await _userManager.UpdateAsync(user);
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordDTO transferObject)
        {
            var user = await _userManager.FindByIdAsync(transferObject.Id);
            var result = await _userManager.ChangePasswordAsync(user, transferObject.OldPassword, transferObject.NewPassword);
            return result;
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IdentityResult> DeleteAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return await _userManager.DeleteAsync(user); ;
        }

        /// <summary>
        /// Remove User Role
        /// </summary>
        /// <param name="user"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task<IdentityResult> RemoveUserRoleAsync(User user, string role)
        {
            return await _userManager.RemoveFromRoleAsync(user, role);
        }
    }
}
