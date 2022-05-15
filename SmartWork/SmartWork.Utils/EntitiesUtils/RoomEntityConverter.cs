using SmartWork.Core.Abstractions.EntityConvertors;
using SmartWork.Core.DTOs.RoomDTOs;
using SmartWork.Core.Entities;
using System;

namespace SmartWork.Utils.EntitiesUtils
{
    public class RoomEntityConverter :
        IEntityConverter<Room, InfoRoomDTO, AddRoomDTO, UpdateRoomDTO>
    {
        public Room ToEntity(InfoRoomDTO transferObject)
        {
            return new Room
            {
                Id = transferObject.Id,
                OfficeId = transferObject.OfficeId,
                Name = transferObject.Name,
                Number = transferObject.Number == string.Empty ? null : Convert.ToInt32(transferObject.Number),
                Square = Convert.ToInt32(transferObject.Square),
                PhotoFileName = transferObject.PhotoFileName,
                Equipment = transferObject.Equipment
            };
        }

        public Room ToEntity(AddRoomDTO transferObject)
        {
            return new Room
            {
                OfficeId = transferObject.OfficeId,
                Name = transferObject.Name,
                Number = transferObject.Number == string.Empty ? null : Convert.ToInt32(transferObject.Number),
                Square = Convert.ToInt32(transferObject.Square),
                PhotoFileName = transferObject.PhotoFileName
            };
        }

        public Room ToEntity(UpdateRoomDTO transferObject)
        {
            return new Room
            {
                Id = transferObject.Id,
                OfficeId = transferObject.OfficeId,
                Name = transferObject.Name,
                Number = transferObject.Number == string.Empty ? null : Convert.ToInt32(transferObject.Number),
                Square = Convert.ToInt32(transferObject.Square),
                PhotoFileName = transferObject.PhotoFileName,
                Equipment = transferObject.Equipment
            };
        }
    }
}
