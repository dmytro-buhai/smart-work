using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.UserDTOs;
using SmartWork.Core.Entities;
using SmartWork.Utils.ActionFilters;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartWork.API.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;

        public AuthController(IUserService userService, UserManager<User> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public Task<ActionResult<UserDTO>> Login(LoginUserDTO model)
        {
            return _userService.LoginAsync(model);
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult<UserDTO>> Register(RegisterUserDTO transferObject)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == transferObject.Email))
            {
                ModelState.AddModelError("email", "email taken");
                return ValidationProblem();
            }

            if (await _userManager.Users.AnyAsync(x => x.UserName == transferObject.Username))
            {
                ModelState.AddModelError("username", "Username taken");
                return ValidationProblem();
            }

            return await _userService.RegisterAsync(transferObject);
        }

        [HttpGet("Account")]
        public Task<ActionResult<UserDTO>> GetCurrentUser()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            return _userService.GetCurrentUserAsync(userEmail);
        }

        [HttpPost("Logout")]
        public Task<ActionResult> Logout()
        {
            return _userService.Logout();
        }
    }
}
