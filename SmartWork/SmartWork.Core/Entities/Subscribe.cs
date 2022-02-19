using System;

namespace SmartWork.Core.Entities
{
    public class Subscribe : Entity
    {
        public int SubscribeDetailId { get; set; }
        public string UserId { get; set; }
        public DateTime StartSubscribe { get; set; }
        public DateTime EndSubscribe { get; set; }            
        public virtual SubscribeDetail SubscribeDetail { get; set; }
        public virtual User User { get; set; }
    }
}