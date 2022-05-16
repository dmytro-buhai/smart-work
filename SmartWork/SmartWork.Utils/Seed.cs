﻿using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.CompanyDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartWork.Utils
{
    public class Seed
    {
        private readonly ICompanyService _companyService;

        public Seed(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task SeedData()
        {
            var result = await _companyService.AnyAsync();

            if (result.GetType() == typeof(OkObjectResult))
            {
                var isAnyCompanies = (bool)((OkObjectResult)result).Value;

                if (isAnyCompanies) return;

                var companies = new List<AddCompanyDTO>
                {
                    new AddCompanyDTO
                    {
                        Name = "SmartWork company inc.",
                        Address = "SmartWork street, 64",
                        PhoneNumber = "661945873",
                        Description = "SmartWork is the best company for you",
                        PhotoFileName = "default_company_photo_file_name"
                    }
                };

                await _companyService.AddAsync(companies);
            }
        }
    }
}
