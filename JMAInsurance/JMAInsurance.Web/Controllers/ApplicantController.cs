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
            var applicant = new ApplicantVM();
            if (Session["Tracker"] != null)
            {
                var tracker = (Guid)Session["Tracker"];
                applicant = Mapper.Map<ApplicantDto, ApplicantVM>(_applicantService.GetApplicantsByTraker(tracker));
            }
            return View(applicant);
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

                    // Mapper.Map(vm, existingApplicant);
                    existingApplicant.FirstName = vm.FirstName;
                    existingApplicant.LastName = vm.LastName;
                    existingApplicant.Email = vm.Email;
                    existingApplicant.Dob = vm.Dob;
                    existingApplicant.HighestEducation = vm.HighestEducation;
                    existingApplicant.LicenseStatus = vm.LicenseStatus;
                    existingApplicant.MaritalStatus = vm.MaritalStatus;
                    existingApplicant.LicenseStatus = vm.LicenseStatus;
                    existingApplicant.Phone = vm.Phone;
                    existingApplicant.YearsLicensed = vm.YearsLicensed;
                    existingApplicant.ApplicantTracker = tracker;
                    _applicantService.Update(existingApplicant);
                }
                else
                {
                    var newApplicant =  new ApplicantDto() ;
                    newApplicant.FirstName = vm.FirstName;
                    newApplicant.LastName = vm.LastName;
                    newApplicant.Email = vm.Email;
                    newApplicant.Dob = vm.Dob;
                    newApplicant.HighestEducation = vm.HighestEducation;
                    newApplicant.LicenseStatus = vm.LicenseStatus;
                    newApplicant.MaritalStatus = vm.MaritalStatus ;
                    newApplicant.LicenseStatus = vm.LicenseStatus;
                    newApplicant.Phone = vm.Phone;
                    newApplicant.YearsLicensed = vm.YearsLicensed;
                    newApplicant.ApplicantTracker = tracker;
                    _applicantService.Create(newApplicant);
                }

                return RedirectToAction("AddressInfo", "Address");
            }

            return View(vm);
        }
    }
}