using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.UserDTOs;
using SmartWork.Core.Entities;
using SmartWork.Utils.ActionFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartWork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet("List")]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userService.GetUsersAsync((u => u.Id != string.Empty));
        }

        // GET: api/User/Profile
        [HttpGet("Profile")]
        public Task<InfoUserDTO> GetUserProfile()
        {
            return _userService.GetUserProfileAsync(this.User);
        }

        // POST: api/User/5
        [HttpPost("{id}")]
        public Task<User> GetUserById(string id)
        {
            return _userService.GetUserByIdAsync(id);
        }

        // POST: api/User/Login
        [HttpPost("Login")]
        public Task<ActionResult<UserDTO>> Login(LoginUserDTO model)
        {
            return _userService.LoginAsync(model);
        }

        // POST: api/User/Register
        [HttpPost("Register")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public Task<IdentityResult> Register(RegisterUserDTO transferObject)
        {
            return _userService.RegisterAsync(transferObject);
        }

        // POST: api/User/Logout
        [HttpPost("Logout")]
        public Task<ActionResult> Logout()
        {
            return _userService.Logout();
        }

        // PUT: api/User/Update
        [HttpPut("Update")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public Task<IdentityResult> Update(UpdateUserDTO transferObject)
        {
            return _userService.UpdateAsync(transferObject);
        }

        // DELETE: api/User/Delete/5
        [HttpDelete("Delete/{id}")]
        public Task<IdentityResult> Delete(string id)
        {
            return _userService.DeleteAsync(id);
        }
    }
}
