using JMAInsurance.Models.Dto;

namespace JMAInsurance.Models.ViewModel
{
    public class AddressesVM
    {
        public AddressDto MainAddress { get; set; }
        public AddressDto MailingAddress { get; set; }
    }
}