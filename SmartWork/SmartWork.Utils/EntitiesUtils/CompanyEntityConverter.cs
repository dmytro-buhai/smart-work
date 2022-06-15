using SmartWork.Core.Abstractions.EntityConvertors;
using SmartWork.Core.DTOs.CompanyDTOs;
using SmartWork.Core.Entities;
using System.Collections.Generic;

namespace SmartWork.Utils.EntitiesUtils
{
    public class CompanyEntityConverter : ICompanyEntityConverter
    {
        public Company ToEntity(AddCompanyDTO transferObject)
        {
            return new Company
            {
                Name = transferObject.Name,
                Address = transferObject.Address,
                PhoneNumber = transferObject.PhoneNumber,
                Description = transferObject.Description,
                PhotoFileName = transferObject.PhotoFileName,
                Host = transferObject.Host
            };
        }

        public Company ToEntity(UpdateCompanyDTO transferObject)
        {
            return new Company
            {
                Id = transferObject.Id,
                Name = transferObject.Name,
                Address = transferObject.Address,
                PhoneNumber = transferObject.PhoneNumber,
                Description = transferObject.Description,
                PhotoFileName = transferObject.PhotoFileName
            };
        }

        public IEnumerable<Company> ToEntities(IEnumerable<AddCompanyDTO> transferObjects)
        {
            var companies = new List<Company>();

            foreach (var transferObject in transferObjects)
            {
                companies.Add(ToEntity(transferObject));
            }

            return companies;
        }

        public IEnumerable<Company> ToEntities(IEnumerable<UpdateCompanyDTO> transferObjects)
        {
            var companies = new List<Company>();

            foreach (var transferObject in transferObjects)
            {
                companies.Add(ToEntity(transferObject));
            }

            return companies;
        }
    }
}
