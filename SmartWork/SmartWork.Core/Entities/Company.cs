namespace SmartWork.Core.Entities
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string PhotoFileName { get; set; }
    } 
}