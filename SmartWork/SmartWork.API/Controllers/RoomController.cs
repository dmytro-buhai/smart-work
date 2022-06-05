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
        public async Task<IActionResult> IsAnyAsync()
        {
            var result = await _roomService.AnyAsync();

            if (result)
            {
                return new OkObjectResult(ResponseResult.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [AllowAnonymous]
        [HttpPost("Rooms/List")]
        public async Task<IActionResult> GetRoomsListAsync(PageInfo pageInfo)
        {
            var roomsList = await _roomService.GetAsync(pageInfo);

            if (roomsList != null)
            {
                return new OkObjectResult(roomsList);
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [AllowAnonymous]
        [HttpPost("RoomsWithStatistic/List")]
        public async Task<IActionResult> GetRoomsListWithStatisticAsync(PageInfo pageInfo)
        {
            var roomsList = await _roomService.GetAsyncWithInclude(pageInfo, "Statistics");

            if (roomsList != null)
            {
                return new OkObjectResult(roomsList);
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [AllowAnonymous]
        [HttpPost("RoomsWithSubscribeDetails/List")]
        public async Task<IActionResult> GetRoomsListWithSubscribeDetailsAsync(PageInfo pageInfo)
        {
            var roomsList = await _roomService.GetAsyncWithInclude(pageInfo, "SubscribeDetails");

            if (roomsList != null)
            {
                return new OkObjectResult(roomsList);
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [AllowAnonymous]
        [HttpGet("[controller]/FindById/{id}")]
        public async Task<IActionResult> FindByIdAsync(int id)
        {
            var room = await _roomService.FindAsync(id);

            if (room != null)
            {
                return new OkObjectResult(room);
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [AllowAnonymous]
        [HttpGet("[controller]/GetRoomInfoById/{id}")]
        public async Task<IActionResult> GetRoomInfoByIdAsync(int id)
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
        public async Task<IActionResult> AddAsync(AddRoomDTO addRoomDTO)
        {
            var result = await _roomService.AddAsync(addRoomDTO);

            if (result)
            {
                return new OkObjectResult(ResponseResult.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [HttpPut("[controller]/Update")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateAsync(UpdateRoomDTO updateRoomDTO)
        {
            var result = await _roomService.UpdateAsync(updateRoomDTO);

            if (result)
            {
                return new OkObjectResult(ResponseResult.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [HttpDelete("[controller]/Delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _roomService.RemoveAsync(id);

            if (result)
            {
                return new OkObjectResult(ResponseResult.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [HttpPut("[controller]/UpdateSubscribeDetails")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateSubscribeDetailsAsync(UpdateSubscribeDetailDTO newSubscribeDetails)
        {
            var result = await _roomService.UpdateSubscribeDetails(newSubscribeDetails);

            if (result)
            {
                return new OkObjectResult(ResponseResult.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }
    }
}
