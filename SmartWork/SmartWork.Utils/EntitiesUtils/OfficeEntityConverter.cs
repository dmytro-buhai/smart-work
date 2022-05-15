using SmartWork.Core.Abstractions.EntityConvertors;
using SmartWork.Core.DTOs.OfficeDTOs;
using SmartWork.Core.Entities;

namespace SmartWork.Utils.EntitiesUtils
{
    public class OfficeEntityConverter : 
        IEntityConverter<Office, InfoOfficeDTO, AddOfficeDTO, UpdateOfficeDTO>
    {
        public Office ToEntity(InfoOfficeDTO transferObject)
        {
            return new Office
            {
                Id = transferObject.Id,
                CompanyId = transferObject.CompanyId,
                Name = transferObject.Name,
                Address = transferObject.Address,
                PhoneNumber = transferObject.PhoneNumber,
                PhotoFileName = transferObject.PhotoFileName,
                IsFavourite = transferObject.IsFavourite,
                Subscribes = transferObject.Subscribes,
                Rooms = transferObject.Rooms
            };
        }

        public Office ToEntity(AddOfficeDTO transferObject)
        {
            return new Office
            {
                CompanyId = transferObject.CompanyId,
                Name = transferObject.Name,
                Address = transferObject.Address,
                PhoneNumber = transferObject.PhoneNumber,
                PhotoFileName = transferObject.PhotoFileName,
                IsFavourite = transferObject.IsFavourite
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
                IsFavourite = transferObject.IsFavourite,
                Subscribes = transferObject.Subscribes,
                Rooms = transferObject.Rooms
            };
        }
    }
}
