using JMAInsurance.Models.Dto;

namespace JMAInsurance.Application.Service.Address
{
    public interface IAddressService
    {
        void Create(AddressDto addressDto);
        void Update(AddressDto addressDto);
        AddressDto GetAddressbyApplicantId(int ApplicantId , bool IsMailing);

    }
}
