using SmartWork.Core.Entities;
using SmartWork.Core.ViewModels.Company;
using SmartWork.Utils.CompanyUtils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartWork.Utils.Extensions
{
    public static class CompanyConverterExtensions
    {
        private static readonly CompanyModelConverter ModelConverter = new CompanyModelConverter();

        public static List<Company> AddModelsToEntity(this IEnumerable<AddCompanyViewModel> models)
        {
            var companies = new List<Company>();

            foreach (var model in models)
            {
                companies.Add(ModelConverter.AddModelToEntity(model));
            }

            return companies;
        }

        public static List<Company> UpdateModelsToEntity(this IEnumerable<UpdateCompanyViewModel> models)
        {
            var companies = new List<Company>();

            foreach (var model in models)
            {
                companies.Add(ModelConverter.UpdateModelToEntity(model));
            }

            return companies;
        }
    }
}
