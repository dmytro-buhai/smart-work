using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.Abstractions.Services.Base;
using SmartWork.Core.Entities;
using SmartWork.Core.Enums;
using SmartWork.Core.Models;
using SmartWork.Core.ViewModels.Company;
using SmartWork.Utils.CompanyUtils;
using SmartWork.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartWork.BLL.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IEntityService<Company> _generalCompanyService;
        private readonly CompanyModelConverter _modelConverter;

        public CompanyService(IEntityService<Company> generalCompanyService)
        {
            _generalCompanyService = generalCompanyService;
            _modelConverter = new CompanyModelConverter();
        }

        public async Task<IActionResult> AddAsync(AddCompanyDTO transferObject)
        {
            var company = _modelConverter.ToEntity(transferObject);

            if (await _generalCompanyService.AddAsync(company))
            {
                return new OkObjectResult(Response.GetResponse(ResponseType.Success));
            }
                
            return new BadRequestObjectResult(Response.GetResponse(ResponseType.Failed));
        }

        public async Task<IActionResult> AddAsync(IEnumerable<AddCompanyDTO> transferObjects)
        {
            var companies = transferObjects.ToEntities();

            if (await _generalCompanyService.AddAsync(companies))
            {
                return new OkObjectResult(Response.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(Response.GetResponse(ResponseType.Failed));
        }

        public async Task<IActionResult> FindAsync(int id)
        {
            var company = await _generalCompanyService.FindAsync(id);

            if(company != null)
            {
                return new OkObjectResult(company);
            }

            return new BadRequestObjectResult(Response.GetResponse(ResponseType.Failed));
        }

        public async Task<IActionResult> FindAsync(Expression<Func<Company, bool>> expression)
        {
            var company = await _generalCompanyService.FindAsync(expression);

            if (company != null)
            {
                return new OkObjectResult(company);
            }

            return new BadRequestObjectResult(Response.GetResponse(ResponseType.Failed));
        }

        public async Task<IActionResult> AnyAsync(Expression<Func<Company, bool>> expression = null)
        {
            return new OkObjectResult(await _generalCompanyService.AnyAsync(expression));
        }

        public async Task<IActionResult> GetAsync(Expression<Func<Company, bool>> expression)
        {
            return new OkObjectResult(await _generalCompanyService.GetAsync(expression));
        }

        public async Task<IActionResult> RemoveAsync(Company company)
        {
            if (await _generalCompanyService.RemoveAsync(company))
            {
                return new OkObjectResult(Response.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(Response.GetResponse(ResponseType.Failed));
        }

        public async Task<IActionResult> RemoveAsync(IEnumerable<Company> companies)
        {
            if (await _generalCompanyService.RemoveAsync(companies))
            {
                return new OkObjectResult(Response.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(Response.GetResponse(ResponseType.Failed));
        }

        public async Task<IActionResult> UpdateAsync(UpdateCompanyDTO transferObject)
        {
            var company = _modelConverter.ToEntity(transferObject);

            if (await _generalCompanyService.UpdateAsync(company))
            {
                return new OkObjectResult(Response.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(Response.GetResponse(ResponseType.Failed));           
        }

        public async Task<IActionResult> UpdateAsync(IEnumerable<UpdateCompanyDTO> transferObjects)
        {
            var companies = transferObjects.ToEntities();

            if (await _generalCompanyService.UpdateAsync(companies))
            {
                return new OkObjectResult(Response.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(Response.GetResponse(ResponseType.Failed));
        }
    }
}
