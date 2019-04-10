using AutoMapper;
using JMAInsurance.Application.Service.Applicants;
using JMAInsurance.ApplicationShared.InfrastructureShared.DataExport;
using JMAInsurance.Models.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace JMAInsurance.Web.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IApplicantService _applicantService;
        public ServiceController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }
        public ActionResult GetApplicantsForReminders()
        {
            var applicants = _applicantService.GetAll();
            var vmApplicants = new List<ApplicantVM>();
            foreach (var app in applicants)
            {
                vmApplicants.Add(Mapper.Map<ApplicantVM>(app));
            }

            return new XMLResult(vmApplicants);
        }

    }
}