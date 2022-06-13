using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.UserDTOs;
using SmartWork.Core.Entities;
using SmartWork.Core.Models;
using SmartWork.Utils.ActionFilters;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartWork.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Users/List")]
        public async Task<List<User>> GetUsers(PageInfo pageInfo)
        {
            return await _userService.GetUsersAsync(pageInfo);
        }

        [HttpGet("[controller]/Profile")]
        public Task<InfoUserDTO> GetUserProfile()
        {
            return _userService.GetUserProfileAsync(this.User);
        }

        [HttpPost("[controller]/{id}")]
        public Task<User> GetUserById(string id)
        {
            return _userService.GetUserByIdAsync(id);
        }

        [HttpPut("[controller]/Update")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public Task<IdentityResult> Update(UpdateUserDTO transferObject)
        {
            return _userService.UpdateAsync(transferObject);
        }

        [HttpDelete("[controller]/Delete/{id}")]
        public Task<IdentityResult> Delete(string id)
        {
            return _userService.DeleteAsync(id);
        }
    }
}
