using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.OfficeDTOs;
using SmartWork.Core.Entities;
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
        public Task<IActionResult> IsAnyAsync() =>
           _officeService.AnyAsync();

        [AllowAnonymous]
        [HttpPost("Offices/List")]
        public Task<IActionResult> Get(PageInfo pageInfo) =>
            _officeService.GetAsync(pageInfo);

        [AllowAnonymous]
        [HttpGet("[controller]/FindById/{id}")]
        public Task<IActionResult> FindById(int id) =>
            _officeService.FindAsync(id);

        [HttpPost("[controller]/Add")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public Task<IActionResult> Add(AddOfficeDTO model) =>
            _officeService.AddAsync(model);

        [HttpPut("[controller]/Update")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public Task<IActionResult> Update(UpdateOfficeDTO model) =>
             _officeService.UpdateAsync(model);

        [HttpDelete("[controller]/Delete")]
        public Task<IActionResult> Delete(Office company) =>
             _officeService.RemoveAsync(company);
    }
}
