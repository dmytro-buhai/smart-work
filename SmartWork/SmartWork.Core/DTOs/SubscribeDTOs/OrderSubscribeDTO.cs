using SmartWork.Core.Abstractions;
using System;

namespace SmartWork.Core.DTOs.SubscribeDTOs
{
    public class OrderSubscribeDTO : IDTO
    {
        public int RoomId { get; set; }
        public string Username { get; set; }
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
