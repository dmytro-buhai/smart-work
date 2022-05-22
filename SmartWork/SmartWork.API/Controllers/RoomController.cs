using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.RoomDTOs;
using SmartWork.Core.Entities;
using SmartWork.Utils.ActionFilters;
using System.Threading.Tasks;

namespace SmartWork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("IsAny")]
        public Task<IActionResult> IsAnyAsync() =>
            _roomService.AnyAsync();

        [HttpGet("GetRooms")]
        public Task<IActionResult> Get() =>
            _roomService.GetAsync(c => c.Id != 0);

        [HttpGet("FindById")]
        public Task<IActionResult> FindById(int id) =>
            _roomService.FindAsync(id);

        [HttpPost("Add")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public Task<IActionResult> Add(AddRoomDTO model) =>
            _roomService.AddAsync(model);

        [HttpPut("Update")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public Task<IActionResult> Update(UpdateRoomDTO model) =>
            _roomService.UpdateAsync(model);

        [HttpDelete("Delete")]
        public Task<IActionResult> Delete(Room company) =>
            _roomService.RemoveAsync(company);
    }
}
