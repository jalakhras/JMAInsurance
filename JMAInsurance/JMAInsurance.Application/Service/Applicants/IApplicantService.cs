using JMAInsurance.Models.Dto;
using System;
using System.Collections.Generic;

namespace JMAInsurance.Application.Service.Applicants
{
    public interface IApplicantService
    {
        ApplicantDto GetApplicantsByTraker(Guid traker);
        void Create(ApplicantDto applicantDto);
        void Update(ApplicantDto applicantDto);
        IEnumerable<ApplicantDto> GetAll();
    }
}
