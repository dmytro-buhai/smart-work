using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.RoomDTOs;
using SmartWork.Core.DTOs.SubscribeDTOs;
using SmartWork.Core.Entities;
using SmartWork.Core.Enums;
using SmartWork.Core.Models;
using SmartWork.Utils.ActionFilters;
using System.Threading.Tasks;

namespace SmartWork.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [AllowAnonymous]
        [HttpGet("Rooms/IsAny")]
        public Task<IActionResult> IsAnyAsync() =>
            _roomService.AnyAsync();

        [AllowAnonymous]
        [HttpPost("Rooms/List")]
        public Task<IActionResult> Get(PageInfo pageInfo) =>
            _roomService.GetAsync(pageInfo);

        [AllowAnonymous]
        [HttpPost("RoomsWithStatistics/List")]
        public Task<IActionResult> GetWithStatistics(PageInfo pageInfo) =>
            _roomService.GetAsyncWithInclude(pageInfo, "Statistics");

        [AllowAnonymous]
        [HttpPost("RoomsWithSubscribeDetails/List")]
        public Task<IActionResult> GetWithSubscribeDetails(PageInfo pageInfo) =>
            _roomService.GetAsyncWithInclude(pageInfo, "SubscribeDetails");

        [AllowAnonymous]
        [HttpGet("[controller]/FindById/{id}")]
        public Task<IActionResult> FindById(int id) =>
            _roomService.FindAsync(id);

        [AllowAnonymous]
        [HttpGet("[controller]/GetRoomInfoById/{id}")]
        public async Task<IActionResult> GetRoomInfoById(int id)
        {
            var roomInfo = await _roomService.GetRoomInfoById(id);

            if(roomInfo == null)
            {
                return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
            }

            return new OkObjectResult(roomInfo);
        }
            

        [HttpPost("[controller]/Add")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public Task<IActionResult> Add(AddRoomDTO model) =>
            _roomService.AddAsync(model);

        [HttpPut("[controller]/Update")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public Task<IActionResult> Update(UpdateRoomDTO model) =>
            _roomService.UpdateAsync(model);

        [HttpDelete("[controller]/Delete")]
        public Task<IActionResult> Delete(Room company) =>
            _roomService.RemoveAsync(company);

        [HttpPut("[controller]/UpdateSubscribeDetails/{roomId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateSubscribeDetailsAsync(int roomId, UpdateSubscribeDetailDTO newSubscribeDetails)
        {
            var result = await _roomService.UpdateSubscribeDetails(roomId, newSubscribeDetails);

            if (result)
            {
                return new OkObjectResult(ResponseResult.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }
    }
}
