using SmartWork.Core.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace SmartWork.Core.ViewModels.Company
{
    public class AddCompanyDTO : IViewModel
    {
        [Display(Name = "Company name")]
        public string Name { get; set; }

        [Display(Name = "Company address")]
        public string Address { get; set; }

        [Display(Name = "Company phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "About company")]
        public string Description { get; set; }

        [Display(Name = "Company photo")]
        public string PhotoFileName { get; set; }
    }
}
