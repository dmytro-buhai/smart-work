using SmartWork.Core.Abstractions;
using SmartWork.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace SmartWork.Core.DTOs.RoomDTOs
{
    public class AddRoomDTO : IDTO
    {
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

        public string Host { get; set; }

        public int SubscribeForDay { get; set; }
        public int SubscribeForWeek { get; set; }
        public int SubscribeForMonth { get; set; }
    }
}
