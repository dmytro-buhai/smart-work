using System;

namespace SmartWork.Core.Entities
{
    public class Subscribe : Entity
    {
        public int RoomId { get; set; }
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }            
        public virtual Room Room { get; set; }
        public virtual User User { get; set; }
    }
}