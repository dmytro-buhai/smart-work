using System.Collections.Generic;

namespace SmartWork.Core.Entities
{
    public class Room : Entity
    {
        public int OfficeId { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int Square { get; set; }
        public string PhotoFileName { get; set; }
        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}