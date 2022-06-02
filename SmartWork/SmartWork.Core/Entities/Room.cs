using System.Collections.Generic;

namespace SmartWork.Core.Entities
{
    public class Room : Entity
    {
        public int OfficeId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int Square { get; set; }
        public int AmountOfWorkplaces { get; set; }
        public string PhotoFileName { get; set; }
        public virtual ICollection<Equipment> Equipment { get; set; }
        public virtual ICollection<Statistic> Statistics { get; set; }
    }
}