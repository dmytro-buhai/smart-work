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

        [AllowAnonymous]
        [HttpGet("Companies/IsAny")]
        public Task<IActionResult> IsAnyAsync() => 
            _companyService.AnyAsync();

        [AllowAnonymous]
        [HttpGet("Companies/List")]
        public Task<IActionResult> Get() => 
            _companyService.GetAsync(c => c.Id != 0);

        [AllowAnonymous]
        [HttpGet("[controller]/FindById/{id}")]
        public Task<IActionResult> FindById(int id) =>
            _companyService.FindAsync(id);

        [HttpPost("[controller]/Add")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public Task<IActionResult> Add(AddCompanyDTO model) => 
            _companyService.AddAsync(model);

        [HttpPut("[controller]/Update")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public Task<IActionResult> Update(UpdateCompanyDTO model) =>
             _companyService.UpdateAsync(model);

        [HttpDelete("[controller]/Delete")]
        public Task<IActionResult> Delete(Company company) =>
             _companyService.RemoveAsync(company);
    }
}
