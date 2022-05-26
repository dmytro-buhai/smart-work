using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("List")]
        public Task<IActionResult> Get() =>
            _officeService.GetAsync(c => c.Id != 0);

        [HttpGet("FindById/{id}")]
        public Task<IActionResult> FindById(int id) =>
            _officeService.FindAsync(id);

        [Authorize]
        [HttpPost("Add")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public Task<IActionResult> Add(AddOfficeDTO model) =>
            _officeService.AddAsync(model);

        [Authorize]
        [HttpPut("Update")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public Task<IActionResult> Update(UpdateOfficeDTO model) =>
             _officeService.UpdateAsync(model);

        [Authorize]
        [HttpDelete("Delete")]
        public Task<IActionResult> Delete(Office company) =>
             _officeService.RemoveAsync(company);
    }
}
