using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartWork.API.Extensions;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.CompanyDTOs;
using SmartWork.Core.Enums;
using SmartWork.Core.Models;
using SmartWork.Utils.ActionFilters;
using System.Threading.Tasks;

namespace SmartWork.API.Controllers
{
    [Route("api/")]
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
        public async Task<IActionResult> IsAnyAsync() 
        { 
            var result = await _companyService.AnyAsync();

            if (result)
            {
                return new OkObjectResult(ResponseResult.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [AllowAnonymous]
        [HttpGet("Companies/List")]
        public async Task<IActionResult> GetCompaniesAsync([FromQuery] PagingParams param)
        {
            var companyList = await _companyService.GetPagedListAsync(param);

            if (companyList != null)
            {
                Response.AddPaginationHeader(companyList.CurrentPage, companyList.PageSize,
                    companyList.TotalCount, companyList.TotalPages);
                return new OkObjectResult(companyList);
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [AllowAnonymous]
        [HttpPost("Companies/FullList")]
        public async Task<IActionResult> GetCompaniesFullListAsync(PageInfo pageInfo) 
        {
            var companiesList = await _companyService.GetAsync(pageInfo);

            if (companiesList != null)
            {
                return new OkObjectResult(companiesList);
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        } 

        [AllowAnonymous]
        [HttpGet("[controller]/FindById/{id}")]
        public async Task<IActionResult> FindByIdAsync(int id)
        {
            var company = await _companyService.FindAsync(id);

            if (company != null)
            {
                return new OkObjectResult(company);
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [HttpPost("[controller]/Add")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddAsync(AddCompanyDTO addCompanyDTO)
        {
            var result = await _companyService.AddAsync(addCompanyDTO);

            if (result != default)
            {
                return new OkObjectResult(result);
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [HttpPut("[controller]/Update")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateAsync(UpdateCompanyDTO updateCompanyDTO)
        {
            var result = await _companyService.UpdateAsync(updateCompanyDTO);

            if (result)
            {
                return new OkObjectResult(ResponseResult.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }

        [HttpDelete("[controller]/Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _companyService.RemoveAsync(id);

            if (result)
            {
                return new OkObjectResult(ResponseResult.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(ResponseResult.GetResponse(ResponseType.Failed));
        }
    }
}
