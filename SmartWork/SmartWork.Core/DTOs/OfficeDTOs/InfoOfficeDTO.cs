using SmartWork.Core.Abstractions;
using SmartWork.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartWork.Core.DTOs.OfficeDTOs
{
    public class InfoOfficeDTO : IDTO
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }

        [Display(Name = "Office name")]
        public string Name { get; set; }

        [Display(Name = "Office address")]
        public string Address { get; set; }

        [Display(Name = "Office phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Office photo")]
        public string PhotoFileName { get; set; }

        public bool IsFavourite { get; set; }

        public ICollection<Subscribe> Subscribes { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
