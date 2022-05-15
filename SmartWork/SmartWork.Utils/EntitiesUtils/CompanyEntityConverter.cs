using SmartWork.Core.Abstractions.EntityConvertors;
using SmartWork.Core.DTOs.CompanyDTOs;
using SmartWork.Core.Entities;


namespace SmartWork.Utils.EntitiesUtils
{
    public class CompanyEntityConverter :
        IEntityConverter<Company, InfoCompanyDTO, AddCompanyDTO, UpdateCompanyDTO>
    {

        public Company ToEntity(InfoCompanyDTO transferObject)
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

        public Company ToEntity(AddCompanyDTO transferObject)
        {
            return new Company
            {
                Name = transferObject.Name,
                Address = transferObject.Address,
                PhoneNumber = transferObject.PhoneNumber,
                Description = transferObject.Description,
                PhotoFileName = transferObject.PhotoFileName
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
    }
}
