using SmartWork.Core.DTOs.OfficeDTOs;
using SmartWork.Core.Entities;
using SmartWork.Utils.EntitiesUtils;
using System.Collections.Generic;

namespace SmartWork.Utils.Extensions
{
    public static class OfficeConverterExtensions        
    {
        private static readonly OfficeEntityConverter EntityConverter = new OfficeEntityConverter();

        public static List<Office> ToEntities(this IEnumerable<AddOfficeDTO> transferObjects)
        {
            var offices = new List<Office>();

            foreach (var transferObject in transferObjects)
            {
                offices.Add(EntityConverter.ToEntity(transferObject));
            }

            return offices;
        }

        public static List<Office> ToEntities(this IEnumerable<UpdateOfficeDTO> transferObjects)
        {
            var offices = new List<Office>();

            foreach (var transferObject in transferObjects)
            {
                offices.Add(EntityConverter.ToEntity(transferObject));
            }

            return offices;
        }
    }
}
