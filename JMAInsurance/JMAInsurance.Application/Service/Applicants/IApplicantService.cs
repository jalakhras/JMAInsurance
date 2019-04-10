using JMAInsurance.Models.Dto;
using System;

namespace JMAInsurance.Application.Service.Applicants
{
    public interface IApplicantService
    {
        ApplicantDto GetApplicantsByTraker(Guid traker);
        void Create(ApplicantDto applicantDto);
        void Update(ApplicantDto applicantDto);
        //ApplicantDto GetApplicantsIsMain(Guid traker, bool IsMailing);
    }
}
