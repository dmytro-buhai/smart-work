﻿using SmartWork.Core.Abstractions;
using SmartWork.Core.DTOs.StatisticDTOs;
using SmartWork.Core.DTOs.SubscribeDTOs;
using SmartWork.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartWork.Core.DTOs.RoomDTOs
{
    public class InfoRoomDTO : IDTO
    {
        public int Id { get; set; }

        public int OfficeId { get; set; }
        
        [Display(Name = "Room name")]
        public string Name { get; set; }

        [Display(Name = "Room number")]
        public string Number { get; set; }

        [Display(Name = "Room Square")]
        public string Square { get; set; }

        [Display(Name = "Amount of workplaces")]
        public string AmountOfWorkplaces { get; set; }

        [Display(Name = "Room photo")]
        public string PhotoFileName { get; set; }

        public ICollection<Equipment> Equipment { get; set; }
        public ICollection<InfoSubscribeDetailDTO> SubscribeDetails { get; set; }
        public ICollection<InfoStatisticDTO> Statistics { get; set; }
    }
}
