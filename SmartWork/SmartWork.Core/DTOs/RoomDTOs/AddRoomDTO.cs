using SmartWork.Core.Abstractions;
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
        public string Square { get; set; }

        [Display(Name = "Room photo")]
        public string PhotoFileName { get; set; }
    }
}
