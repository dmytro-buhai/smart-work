using SmartWork.Core.Abstractions.EntityConvertors;
using SmartWork.Core.DTOs.OfficeDTOs;
using SmartWork.Core.Entities;
using System.Collections.Generic;

namespace SmartWork.Utils.EntitiesUtils
{
    public class OfficeEntityConverter : IOfficeEntityConverter
    {
        public Office ToEntity(AddOfficeDTO transferObject)
        {
            return new Office
            {
                CompanyId = transferObject.CompanyId,
                Name = transferObject.Name,
                Address = transferObject.Address,
                PhoneNumber = transferObject.PhoneNumber,
                PhotoFileName = transferObject.PhotoFileName,
                IsFavourite = transferObject.IsFavourite,
                Host = transferObject.Host
            };
        }

        public Office ToEntity(UpdateOfficeDTO transferObject)
        {
            return new Office
            {
                Id = transferObject.Id,
                CompanyId = transferObject.CompanyId,
                Name = transferObject.Name,
                Address = transferObject.Address,
                PhoneNumber = transferObject.PhoneNumber,
                PhotoFileName = transferObject.PhotoFileName,
                IsFavourite = transferObject.IsFavourite
            };
        }

        public IEnumerable<Office> ToEntities(IEnumerable<AddOfficeDTO> transferObjects)
        {
            var offices = new List<Office>();

            foreach (var transferObject in transferObjects)
            {
                offices.Add(ToEntity(transferObject));
            }

            return offices;
        }

        public IEnumerable<Office> ToEntities(IEnumerable<UpdateOfficeDTO> transferObjects)
        {
            var offices = new List<Office>();

            foreach (var transferObject in transferObjects)
            {
                offices.Add(ToEntity(transferObject));
            }

            return offices;
        }
    }
}
