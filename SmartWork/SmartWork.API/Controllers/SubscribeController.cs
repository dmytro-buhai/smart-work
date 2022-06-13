using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.SubscribeDTOs;
using SmartWork.Core.Entities;
using SmartWork.Core.Enums;
using SmartWork.Core.Models;
using SmartWork.Utils.ActionFilters;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SmartWork.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService, UserManager<User> userManager)
        {
            _subscribeService = subscribeService;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost("[controller]Details/GetListForRooms")]
        public async Task<IActionResult> FindByIdAsync(int[] roomsIDs)
        {
            var subscribeDetails = await _subscribeService.GetSubscribeDetailsForRooms(roomsIDs);

            if (subscribeDetails != null)
            {
                return new OkObjectResult(subscribeDetails);
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [HttpGet("[controller]s/GetByUser/{username}")]
        public async Task<IActionResult> GetUserSubscribesAsync(string username)
        {
            var user = await GetUserAsync(username);

            if (user == null)
            {
                ModelState.AddModelError("username", "your username does not exist");
                return ValidationProblem();
            }

            var orderedUserSubscribes = await _subscribeService.GetUserSubscribesAsync(user.Id);

            if (orderedUserSubscribes != null)
            {
                return Ok(orderedUserSubscribes);
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [HttpPost("[controller]/OrderUserSubscribe")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> OrderUserSubscribeAsync(OrderSubscribeDTO orderSubscribe)
        {
            var user = await GetUserAsync(orderSubscribe.Username);

            if(user == null)
            {
                ModelState.AddModelError("username", "your username does not exist");
                return ValidationProblem();
            }
            else
            {
                orderSubscribe.UserId = user.Id;
            }

            var orderedUserSubscribe = await _subscribeService.OrderSubscribe(orderSubscribe);

            if (orderedUserSubscribe != null)
            {
                return Ok(orderedUserSubscribe);
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        private async Task<User> GetUserAsync(string username)
        {
            return await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == username);
        }
    }
}
