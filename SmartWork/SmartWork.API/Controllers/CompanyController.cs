using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.CompanyDTOs;
using SmartWork.Core.Entities;
using SmartWork.Utils.ActionFilters;
using System.Threading.Tasks;


namespace SmartWork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("IsAny")]
        public Task<IActionResult> IsAnyAsync() => 
            _companyService.AnyAsync();
        
        [HttpGet("List")]
        public Task<IActionResult> Get() => 
            _companyService.GetAsync(c => c.Id != 0);

        [HttpGet("FindById/{id}")]
        public Task<IActionResult> FindById(int id) =>
            _companyService.FindAsync(id);

        [Authorize]
        [HttpPost("Add")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public Task<IActionResult> Add(AddCompanyDTO model) => 
            _companyService.AddAsync(model);

        [Authorize]
        [HttpPut("Update")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public Task<IActionResult> Update(UpdateCompanyDTO model) =>
             _companyService.UpdateAsync(model);

        [Authorize]
        [HttpDelete("Delete")]
        public Task<IActionResult> Delete(Company company) =>
             _companyService.RemoveAsync(company);
    }
}
