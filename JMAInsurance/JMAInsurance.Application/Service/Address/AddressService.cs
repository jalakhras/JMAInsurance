using System;
using System.Linq;
using AutoMapper;
using JMAInsurance.Entity;
using JMAInsurance.EntityFramwork.Repository;
using JMAInsurance.Models.Dto;

namespace JMAInsurance.Application.Service.Address
{
    public class AddressService : IAddressService
    {
        private readonly IRepository<Applicant> _repositoryApplicant;
        private readonly IRepository<Entity.Address> _repositoryAddress;
        public AddressService(IRepository<Applicant> repositoryApplicant, IRepository<Entity.Address> repositoryAddress)
        {
            _repositoryApplicant = repositoryApplicant;
            _repositoryAddress = repositoryAddress;
        }
        public void Create(AddressDto addressDto)
        {
            _repositoryAddress.Create(Mapper.Map<Entity.Address>(addressDto));
            _repositoryAddress.Save();
        }
        public AddressDto GetAddressbyApplicantId(int ApplicantId, bool IsMailing)
        {
            var address = _repositoryAddress.Get(x => x.ApplicantId == ApplicantId && x.IsMailing == IsMailing).FirstOrDefault();
            var addressDto = Mapper.Map<AddressDto>(address);
            return addressDto; 
        }
        public void Update(AddressDto addressDto)
        {
            _repositoryAddress.Update(Mapper.Map<Entity.Address>(addressDto));
            _repositoryAddress.Save();
        }
    }
}
