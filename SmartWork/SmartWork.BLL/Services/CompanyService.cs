using Microsoft.AspNetCore.Mvc;
using SmartWork.BLL.Services.General;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.Abstractions.Services.Base;
using SmartWork.Core.Entities;
using SmartWork.Core.ViewModels.Company;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartWork.BLL.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly GeneralCompanyService _general;

        public CompanyService(IEntityRepository<Company> repository)
        {
            _general = new GeneralCompanyService(repository);
        }

        public async Task<IActionResult> AddAsync(AddCompanyViewModel model)
        {
            try
            {
                var company = new Company
                {
                    Name = model.Name,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    Description = model.Description,
                    PhotoFileName = model.PhotoFileName
                };

                return await _general.AddAsync(company);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        public async Task<IActionResult> AddAsync(IEnumerable<AddCompanyViewModel> models)
        {
            try
            {
                var companies = new List<Company>();

                foreach(var model in models)
                {
                    var company = new Company
                    {
                        Name = model.Name,
                        Address = model.Address,
                        PhoneNumber = model.PhoneNumber,
                        Description = model.Description,
                        PhotoFileName = model.PhotoFileName
                    };

                    companies.Add(company);
                }

                return await _general.AddAsync(companies);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        public async Task<IActionResult> FindAsync(int id)
        {
            try
            {
                return new OkObjectResult(await _general.FindAsync(id));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        public async Task<IActionResult> FindAsync(Func<Company, bool> expression)
        {
            try
            {
                return new OkObjectResult(await _general.FindAsync(expression));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        public async Task<IActionResult> GetAsync(Func<Company, bool> expression)
        {
            try
            {
                return new OkObjectResult(await _general.GetAsync(expression));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        public async Task<IActionResult> RemoveAsync(int id)
        {
            try
            {
                return new OkObjectResult(await _general.RemoveAsync(id));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        public async Task<IActionResult> RemoveAsync(IEnumerable<int> identifiers)
        {
            try
            {
                return new OkObjectResult(await _general.RemoveAsync(identifiers));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        public async Task<IActionResult> UpdateAsync(UpdateCompanyViewModel model)
        {
            try
            {
                var company = await _general.FindAsync(model.Id);

                if (company == null)
                    return new BadRequestObjectResult("NULL_RESULT");

                company.Name = model.Name;
                company.Address = model.Address;
                company.PhoneNumber = model.PhoneNumber;
                company.Description = model.Description;
                company.PhotoFileName = model.PhotoFileName;

                return new OkObjectResult(await _general.UpdateAsync(company));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        public async Task<IActionResult> UpdateAsync(IEnumerable<UpdateCompanyViewModel> models)
        {
            try
            {
                var companies = new List<Company>();

                foreach(var model in models)
                {
                    var company = await _general.FindAsync(model.Id);

                    if (company == null)
                        return new BadRequestObjectResult("invalid data");

                    company.Name = model.Name;
                    company.Address = model.Address;
                    company.PhoneNumber = model.PhoneNumber;
                    company.Description = model.Description;
                    company.PhotoFileName = model.PhotoFileName;

                    companies.Add(company);
                }

                return new OkObjectResult(await _general.UpdateAsync(companies));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}
