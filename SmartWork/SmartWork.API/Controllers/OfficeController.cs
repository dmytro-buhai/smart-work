using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.OfficeDTOs;
using SmartWork.Core.Entities;
using SmartWork.Utils.ActionFilters;
using System.Threading.Tasks;

namespace SmartWork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeService _officeService;

        public OfficeController(IOfficeService officeService)
        {
            _officeService = officeService;
        }

        [HttpGet("IsAny")]
        public Task<IActionResult> IsAnyAsync() =>
           _officeService.AnyAsync();

        [HttpGet("GetOffices")]
        public Task<IActionResult> Get() =>
            _officeService.GetAsync(c => c.Id != 0);

        [HttpGet("FindById")]
        public Task<IActionResult> FindById(int id) =>
            _officeService.FindAsync(id);

        [HttpPost("Add")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public Task<IActionResult> Add(AddOfficeDTO model) =>
            _officeService.AddAsync(model);

        [HttpPut("Update")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public Task<IActionResult> Update(UpdateOfficeDTO model) =>
             _officeService.UpdateAsync(model);

        [HttpDelete("Delete")]
        public Task<IActionResult> Delete(Office company) =>
             _officeService.RemoveAsync(company);
    }
}
