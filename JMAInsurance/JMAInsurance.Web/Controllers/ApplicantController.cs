using AutoMapper;
using JMAInsurance.Application.Service.Applicants;
using JMAInsurance.Models.Dto;
using JMAInsurance.Web.ViewModels;
using System;
using System.Web.Mvc;

namespace JMAInsurance.Web.Controllers
{
    public class ApplicantController : Controller
    {
        private readonly IApplicantService _applicantService;
        public ApplicantController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }
        // GET: Applicant
        [HttpGet]
        public ActionResult ApplicantInfo()
        {
            var applicantVM = new ApplicantVM();
            if (Session["Tracker"] != null)
            {
                var tracker = (Guid)Session["Tracker"];
                var applicant = Mapper.Map<ApplicantDto, ApplicantVM>(_applicantService.GetApplicantsByTraker(tracker));

                if (applicant != null)
                    applicantVM = applicant;
                else
                    applicantVM.ApplicantTracker = tracker;
            }
            return View(applicantVM);
        }


        [HttpPost]
        public ActionResult ApplicantInfo(ApplicantVM vm)
        {

            if (ModelState.IsValid)
            {
                if (Session["Tracker"] == null)
                {
                    Session["Tracker"] = Guid.NewGuid();
                }
                var tracker = (Guid)Session["Tracker"];

                var existingApplicant = _applicantService.GetApplicantsByTraker(tracker);
                if (existingApplicant != null)
                {

                    Mapper.Instance.Map(vm, existingApplicant);
                    _applicantService.Update(existingApplicant);
                }
                else
                {
                    _applicantService.Create(Mapper.Map<ApplicantDto>(vm));
                }

                return RedirectToAction("AddressInfo", "Address");
            }

            return View(vm);
        }
    }
}