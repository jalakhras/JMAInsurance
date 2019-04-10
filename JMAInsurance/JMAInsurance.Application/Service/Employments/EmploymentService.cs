using AutoMapper;
using JMAInsurance.Entity;
using JMAInsurance.EntityFramwork.Repository;
using JMAInsurance.Models.Dto;

namespace JMAInsurance.Application.Service.Employments
{
    public class EmploymentService : IEmploymentService
    {
        private readonly IRepository<Employment> _repositoryEmployment;
        public EmploymentService(IRepository<Employment> repositoryEmployment)
        {
            _repositoryEmployment = repositoryEmployment;
        }

        public void Create(EmploymentDto employmentDto)
        {
            _repositoryEmployment.Create(Mapper.Map<Employment>(employmentDto));
        }

        public void Update(EmploymentDto employmentDto)
        {
            _repositoryEmployment.Update(Mapper.Map<Employment>(employmentDto));
        }
    }
}
