using SmartWork.Core.Abstractions.ModelConvertors;
using SmartWork.Core.Entities;
using SmartWork.Core.ViewModels.Company;
using System.Collections.Generic;

namespace SmartWork.Utils.CompanyUtils
{
    public class CompanyModelConverter : 
        IModelConverter<Company, InfoCompanyViewModel, AddCompanyViewModel, UpdateCompanyViewModel>
    {

        public Company InfoModelToEntity(InfoCompanyViewModel model)
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

        public Company AddModelToEntity(AddCompanyViewModel model)
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

        public Company UpdateModelToEntity(UpdateCompanyViewModel model)
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
