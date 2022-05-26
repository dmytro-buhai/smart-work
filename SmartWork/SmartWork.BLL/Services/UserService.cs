using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.UserDTOs;
using SmartWork.Core.Entities;
using SmartWork.Core.Models;
using SmartWork.Utils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartWork.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User> _repository;
        private readonly ApplicationSettings _appSettings;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly TokenService _tokenService;
        private readonly ILogger<UserService> _logger;
        //private readonly ISubscribeService _subscribeService;

        public UserService(IUserRepository<User> repository,
            IOptions<ApplicationSettings> applicationSettings,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            TokenService tokenService,
            ILogger<UserService> logger)
        {
            _repository = repository;
            _appSettings = applicationSettings.Value;
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
        public Task<IEnumerable<User>> GetUsersAsync(Expression<Func<User, bool>> expression)
        {
            return _repository.GetAsync(expression);
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
                return new UserDTO
                {
                    DisplayName = user.FullName,
                    Username = user.Email,
                    Token = _tokenService.CreateToken(user)
                };
            }

            return new UnauthorizedResult();
        }

        /// <summary>
        /// Sign up User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IdentityResult> RegisterAsync(RegisterUserDTO transferObject)
        {
            const string userRole = "user";
            var user = new User
            {
                Email = transferObject.Email,
                UserName = transferObject.Email,
                FullName = transferObject.FullName,
                PhoneNumber = transferObject.PhoneNumber,
                DateOfBirth = transferObject.DateOfBirth
            };

            var result = await _userManager.CreateAsync(user, transferObject.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, userRole);
                await _signInManager.SignInAsync(user, false);
            }
            return result;
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
            var user = await _userManager.FindByIdAsync(transferObject.Id);

            user.Email = transferObject.Email;
            user.UserName = transferObject.Email;
            user.FullName = transferObject.FullName;
            user.PhoneNumber = transferObject.PhoneNumber;
            user.DateOfBirth = transferObject.DateOfBirth;

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
