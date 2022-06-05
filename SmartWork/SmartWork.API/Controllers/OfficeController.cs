using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.OfficeDTOs;
using SmartWork.Core.Enums;
using SmartWork.Core.Models;
using SmartWork.Utils.ActionFilters;
using System.Threading.Tasks;

namespace SmartWork.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeService _officeService;

        public OfficeController(IOfficeService officeService)
        {
            _officeService = officeService;
        }

        [AllowAnonymous]
        [HttpGet("Offices/IsAny")]
        public async Task<IActionResult> IsAnyAsync()
        {
            var result = await _officeService.AnyAsync();

            if (result)
            {
                return new OkObjectResult(ResponseResult.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [AllowAnonymous]
        [HttpPost("Offices/List")]
        public async Task<IActionResult> GetOfficesListAsync(PageInfo pageInfo)
        {
            var officesList = await _officeService.GetAsync(pageInfo);

            if (officesList != null)
            {
                return new OkObjectResult(officesList);
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [AllowAnonymous]
        [HttpGet("[controller]/FindById/{id}")]
        public async Task<IActionResult> FindByIdAsync(int id)
        {
            var office = await _officeService.FindAsync(id);

            if (office != null)
            {
                return new OkObjectResult(office);
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [HttpPost("[controller]/Add")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddAsync(AddOfficeDTO addOfficeDTO)
        {
            var result = await _officeService.AddAsync(addOfficeDTO);

            if (result)
            {
                return new OkObjectResult(ResponseResult.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [HttpPut("[controller]/Update")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateAsync(UpdateOfficeDTO updateOfficeDTO)
        {
            var result = await _officeService.UpdateAsync(updateOfficeDTO);

            if (result)
            {
                return new OkObjectResult(ResponseResult.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [HttpDelete("[controller]/Delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _officeService.RemoveAsync(id);

            if (result)
            {
                return new OkObjectResult(ResponseResult.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }
    }
}
