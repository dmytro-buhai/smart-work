using System.Collections.Generic;

namespace SmartWork.Core.Entities
{
    public class Office : Entity
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsFavourite { get; set; }
        public string PhotoFileName { get; set; }
        public virtual ICollection<Subscribe> Subscribes { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}