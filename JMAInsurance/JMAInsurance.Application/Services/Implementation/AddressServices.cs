using JMAInsurance.Application.Services.Interface;
using JMAInsurance.Entity;
using JMAInsurance.Model.Repository;

namespace JMAInsurance.Application.Services.Implementation
{
    public class AddressServices : IAddressServices
    {
        private readonly IRepository<Address> _AddressRepository;

        public AddressServices(IRepository<Address> AddressRepository)
        {
            _AddressRepository = AddressRepository;
        }

        public void GetAll()
        {
            _AddressRepository.GetAll();
        }
    }
}
