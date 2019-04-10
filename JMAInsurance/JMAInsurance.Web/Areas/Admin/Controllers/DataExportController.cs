using AutoMapper;
using JMAInsurance.Application.Service.Applicants;
using JMAInsurance.ApplicationShared.InfrastructureShared.DataExport;
using JMAInsurance.Models.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace JMAInsurance.Web.Areas.Admin.Controllers
{
    public class DataExportController : Controller
    {
        private readonly IApplicantService _applicantService;
        public DataExportController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetQuotesCSV()
        {
            var applicants = _applicantService.GetAll();
            var mappedApplicants = new List<ApplicantVM>();
            foreach (var app in applicants)
            {
                mappedApplicants.Add(Mapper.Map<ApplicantVM>(app));
            }

            return new CSVResult(mappedApplicants, "TestCSVExport.doc");
        }

        
    }
}