using JMAInsurance.Models.Dto;

namespace JMAInsurance.Web.ViewModels
{
    public class AddressesVM
    {
        public AddressDto MainAddress { get; set; }
        public AddressDto MailingAddress { get; set; }
    }
}