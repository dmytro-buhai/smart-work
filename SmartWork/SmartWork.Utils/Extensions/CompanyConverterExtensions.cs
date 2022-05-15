using SmartWork.Core.DTOs.CompanyDTOs;
using SmartWork.Core.Entities;
using SmartWork.Utils.EntitiesUtils;
using System.Collections.Generic;

namespace SmartWork.Utils.Extensions
{
    public static class CompanyConverterExtensions
    {
        private static readonly CompanyEntityConverter EntityConverter = new CompanyEntityConverter();

        public static List<Company> ToEntities(this IEnumerable<AddCompanyDTO> transferObjects)
        {
            var companies = new List<Company>();

            foreach (var transferObject in transferObjects)
            {
                companies.Add(EntityConverter.ToEntity(transferObject));
            }

            return companies;
        }

        public static List<Company> ToEntities(this IEnumerable<UpdateCompanyDTO> transferObjects)
        {
            var companies = new List<Company>();

            foreach (var transferObject in transferObjects)
            {
                companies.Add(EntityConverter.ToEntity(transferObject));
            }

            return companies;
        }
    }
}
