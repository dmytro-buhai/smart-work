using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.CompanyDTOs;
using SmartWork.Core.DTOs.OfficeDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartWork.Utils
{
    public class Seed
    {
        private readonly ICompanyService _companyService;
        private readonly IOfficeService _officeService;

        public Seed(ICompanyService companyService, IOfficeService officeService)
        {
            _companyService = companyService;
            _officeService = officeService;
        }

        public async Task SeedData()
        {
            var result = await _companyService.AnyAsync();

            if (result.GetType() == typeof(OkObjectResult))
            {
                var isAnyCompanies = (bool)((OkObjectResult)result).Value;

                if (!isAnyCompanies)
                {
                    var companies = new List<AddCompanyDTO>
                    {
                        new AddCompanyDTO
                        {
                            Name = "SmartWork company inc.",
                            Address = "SmartWork street, 64",
                            PhoneNumber = "0663248507",
                            Description = "SmartWork is the best company for you",
                            PhotoFileName = "default_company_photo_file_name"
                        }
                    };

                    await _companyService.AddAsync(companies);
                } 
            }

            result = await _officeService.AnyAsync();

            if (result.GetType() == typeof(OkObjectResult))
            {
                var isAnyOffices = (bool)((OkObjectResult)result).Value;

                if (!isAnyOffices)
                {
                    var offices = new List<AddOfficeDTO>
                    {
                        new AddOfficeDTO
                        {
                            CompanyId = 2,
                            Name = "SmartWork the best office",
                            Address = "SmartWork street, 61",
                            PhoneNumber = "0661234567",
                            PhotoFileName = "default_office_photo_file_name",
                            IsFavourite = true
                        },
                        new AddOfficeDTO
                        {
                            CompanyId = 2,
                            Name = "Second SmartWork office",
                            Address = "SmartWork street, 68",
                            PhoneNumber = "0661209567",
                            PhotoFileName = "default_office_photo_file_name",
                            IsFavourite = false
                        }
                    };

                    await _officeService.AddAsync(offices);
                }
            }
        }
    }
}
