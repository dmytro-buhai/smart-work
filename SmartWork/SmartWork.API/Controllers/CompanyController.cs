using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Abstractions.Services.Base;
using SmartWork.Core.Entities;
using SmartWork.Core.ViewModels.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public async Task<IActionResult> IsAnyAsync()
        {
            var result = await _companyService.AnyAsync();
            return result;
        }

        [HttpGet("GetCompanies")]
        public Task<IActionResult> Get() => 
            _companyService.GetAsync(c => c.Id != 0);

        [HttpGet("FindById")]
        public Task<IActionResult> FindById(int id) =>
            _companyService.GetAsync(c => c.Id == id);


        [HttpPost("Add")]
        public Task<IActionResult> Add(AddCompanyViewModel model) =>
            _companyService.AddAsync(model);


        [HttpPut("Update")]
        public Task<IActionResult> Update(UpdateCompanyViewModel model) =>
             _companyService.UpdateAsync(model);

        [HttpDelete("Delete")]
        public Task<IActionResult> Delete(Company company) =>
             _companyService.RemoveAsync(company);
    }
}
