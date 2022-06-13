using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.EquipmentDTOs;
using SmartWork.Core.Enums;
using SmartWork.Core.Models;
using SmartWork.Utils.ActionFilters;
using System.Threading.Tasks;

namespace SmartWork.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpPost("[controller]/AddEquipmentForRoom")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddEquipmentForRoomAsync(AddEquipmentDTO equipmentDTO)
        {
            var result = await _equipmentService.AddEquipmentForRoom(equipmentDTO);

            if (result)
            {
                return new OkObjectResult(ResponseResult.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [HttpPut("[controller]/UpdateEquipmentForRoom")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateEquipmentForRoomAsync(UpdateEquipmentDTO newEquipmentData)
        {
            var result = await _equipmentService.UpdateEquipmentForRoom(newEquipmentData);

            if (result)
            {
                return new OkObjectResult(ResponseResult.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [HttpDelete("[controller]/DeleteEquipment/{id}")]
        public async Task<IActionResult> DeleteEquipmentAsync(int id)
        {
            var result = await _equipmentService.DeleteEquipment(id);

            if (result)
            {
                return new OkObjectResult(ResponseResult.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }
    }
}
