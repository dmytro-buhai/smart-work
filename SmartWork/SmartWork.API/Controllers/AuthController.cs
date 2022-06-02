using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.UserDTOs;
using SmartWork.Utils.ActionFilters;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartWork.API.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
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
        public Task<ActionResult<UserDTO>> Register(RegisterUserDTO transferObject)
        {
            return _userService.RegisterAsync(transferObject);
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
