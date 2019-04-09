using EPM.DataAccess;
using JMAInsurance.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMAInsurance.Application.Service
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
