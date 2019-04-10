using AutoMapper;
using JMAInsurance.Entity;
using JMAInsurance.EntityFramwork.Repository;
using JMAInsurance.Models.Dto;
using System;
using System.Linq;

namespace JMAInsurance.Application.Service.Applicants
{
    public class ApplicantService : IApplicantService
    {
        private readonly IRepository<Applicant> _repositoryApplicant;
        public ApplicantService(IRepository<Applicant> repositoryApplicant)
        {
            _repositoryApplicant = repositoryApplicant;
        }

        public void Create(ApplicantDto applicantDto)
        {
            _repositoryApplicant.Create(Mapper.Map<Applicant>(applicantDto));
            _repositoryApplicant.Save();
        }

        public ApplicantDto GetApplicantsByTraker(Guid tracker)
        {
            var Applicant = _repositoryApplicant.Get(x => x.ApplicantTracker == tracker).FirstOrDefault();
            var ApplicantDto = Mapper.Map<ApplicantDto>(Applicant);
            return ApplicantDto;

        }

        public void Update(ApplicantDto applicantDto)
        {
            _repositoryApplicant.Update(Mapper.Map<Applicant>(applicantDto));
            _repositoryApplicant.Save();
        }
      

    }
}
