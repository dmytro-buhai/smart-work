using SmartWork.Core.Abstractions.EntityConvertors;
using SmartWork.Core.DTOs.RoomDTOs;
using SmartWork.Core.Entities;
using System;
using System.Collections.Generic;

namespace SmartWork.Utils.EntitiesUtils
{
    public class RoomEntityConverter : IRoomEntityConverter
    {
        public IEnumerable<Room> ToEntities(IEnumerable<AddRoomDTO> transferObjects)
        {
            var rooms = new List<Room>();

            foreach (var transferObject in transferObjects)
            {
                rooms.Add(ToEntity(transferObject));
            }

            return rooms;
        }

        public IEnumerable<Room> ToEntities(IEnumerable<UpdateRoomDTO> transferObjects)
        {
            var rooms = new List<Room>();

            foreach (var transferObject in transferObjects)
            {
                rooms.Add(ToEntity(transferObject));
            }

            return rooms;
        }

        public Room ToEntity(AddRoomDTO transferObject)
        {
            return new Room
            {
                OfficeId = transferObject.OfficeId,
                Name = transferObject.Name,
                Number = transferObject.Number,
                Square = transferObject.Square,
                AmountOfWorkplaces = transferObject.AmountOfWorkplaces,
                PhotoFileName = transferObject.PhotoFileName,
                Host = transferObject.Host,
            };
        }

        public Room ToEntity(UpdateRoomDTO transferObject)
        {
            return new Room
            {
                Id = transferObject.Id,
                OfficeId = transferObject.OfficeId,
                Name = transferObject.Name,
                Number = transferObject.Number,
                Square = transferObject.Square,
                AmountOfWorkplaces = transferObject.AmountOfWorkplaces,
                PhotoFileName = transferObject.PhotoFileName,
                SubscribeDetails = transferObject.SubscribeDetails,
                Host = transferObject.Host
            };
        }
    }
}
