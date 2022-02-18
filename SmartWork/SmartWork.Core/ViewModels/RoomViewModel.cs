using System.ComponentModel.DataAnnotations;

namespace SmartWork.Core.ViewModels
{
    public class RoomViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Room number")]
        public string Number { get; set; }

        [Display(Name = "Room photo")]
        public string PhotoFileName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
