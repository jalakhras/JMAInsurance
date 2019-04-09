using JMAInsurance.Entity;
using JMAInsurance.EntityFramwork.Repository;
using System;

namespace JMAInsurance.ApplicationShared.Service
{
    public class ApplicantService : IApplicantService
    {
        private readonly IRepository<Applicant> _repository;
        public ApplicantService(IRepository<Applicant> repository)
        {
            _repository = repository;
        }

        public void GetAll()
        {
            var x = _repository.GetAll();
        }
    }
}
