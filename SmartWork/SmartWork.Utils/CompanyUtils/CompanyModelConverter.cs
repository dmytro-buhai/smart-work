using SmartWork.Core.Abstractions.ModelConvertors;
using SmartWork.Core.Entities;
using SmartWork.Core.ViewModels.Company;

namespace SmartWork.Utils.CompanyUtils
{
    public class CompanyModelConverter : 
        IModelConverter<Company, InfoCompanyDTO, AddCompanyDTO, UpdateCompanyDTO>
    {

        public Company ToEntity(InfoCompanyDTO model)
        {
            return new Company
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                Description = model.Description,
                PhotoFileName = model.PhotoFileName
            };
        }

        public Company ToEntity(AddCompanyDTO model)
        {
            return new Company
            {
                Name = model.Name,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                Description = model.Description,
                PhotoFileName = model.PhotoFileName
            };
        }

        public Company ToEntity(UpdateCompanyDTO model)
        {
            return new Company
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                Description = model.Description,
                PhotoFileName = model.PhotoFileName
            };
        }
    }
}
