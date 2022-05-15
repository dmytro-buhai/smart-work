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

        public static List<Company> ToEntities(this IEnumerable<AddCompanyDTO> models)
        {
            var companies = new List<Company>();

            foreach (var model in models)
            {
                companies.Add(ModelConverter.ToEntity(model));
            }

            return companies;
        }

        public static List<Company> ToEntities(this IEnumerable<UpdateCompanyDTO> models)
        {
            var companies = new List<Company>();

            foreach (var model in models)
            {
                companies.Add(ModelConverter.ToEntity(model));
            }

            return companies;
        }
    }
}
