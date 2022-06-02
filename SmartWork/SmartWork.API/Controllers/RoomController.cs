using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.RoomDTOs;
using SmartWork.Core.Entities;
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
        [HttpGet("[controller]/FindById/{id}")]
        public Task<IActionResult> FindById(int id) =>
            _roomService.FindAsync(id);

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
    }
}
