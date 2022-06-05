using SmartWork.Core.Abstractions;
using SmartWork.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartWork.Core.DTOs.RoomDTOs
{
    public class UpdateRoomDTO : IDTO
    {
        public int Id { get; set; }

        public int OfficeId { get; set; }

        [Display(Name = "Room name")]
        public string Name { get; set; }

        [Display(Name = "Room number")]
        public string Number { get; set; }

        [Display(Name = "Room Square")]
        public int Square { get; set; }

        [Display(Name = "Amount of workplaces")]
        public int AmountOfWorkplaces { get; set; }

        [Display(Name = "Room photo")]
        public string PhotoFileName { get; set; }

        public ICollection<Equipment> Equipment { get; set; }
    }
}
