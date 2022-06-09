using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.Enums;
using SmartWork.Core.Models;
using System.Threading.Tasks;

namespace SmartWork.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
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
    }
}
