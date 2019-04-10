using AutoMapper;
using JMAInsurance.Application.Service.Applicants;
using JMAInsurance.Application.Service.Employments;
using JMAInsurance.Models.Dto;
using JMAInsurance.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace JMAInsurance.Web.Controllers
{
    public class EmploymentController : Controller
    {
        private readonly IApplicantService _applicantService;
        private readonly IEmploymentService _employmentService;
        public EmploymentController(IApplicantService applicantService, IEmploymentService employmentService)
        {
            _applicantService = applicantService;
            _employmentService = employmentService;
        }
        public ActionResult EmploymentInfo()
        {
            if (Session["Tracker"] == null)
            {
                return RedirectToAction("ApplicantInfo", "Applicant");
            }
            var tracker = (Guid)Session["Tracker"];

            var employment = new Employments();
            var existingPrimary = _applicantService.GetApplicantsByTraker(tracker).Employment.FirstOrDefault(x => x.IsPrimary);
            if (existingPrimary != null)
            {
                employment.PrimaryEmployer = Mapper.Map<EmploymentVM>(existingPrimary);
            }

            var existingPrevious = _applicantService.GetApplicantsByTraker(tracker).Employment.FirstOrDefault(x => x.IsPrimary == false);
            if (existingPrevious != null)
            {
                employment.PreviousEmployer = Mapper.Map<EmploymentVM>(existingPrevious);
            }

            return View(employment);
        }
        [HttpPost]
        public ActionResult EmploymentInfo(Employments vm)
        {
            if (Session["Tracker"] == null)
            {
                return RedirectToAction("ApplicantInfo", "Applicant");
            }
            var tracker = (Guid)Session["Tracker"];

            if (ModelState.IsValid)
            {
                var applicant = _applicantService.GetApplicantsByTraker(tracker);

                var existingEmployment = applicant.Employment.FirstOrDefault(x => x.IsPrimary);
                if (existingEmployment != null)
                {
                    Mapper.Map(vm.PrimaryEmployer, existingEmployment);
                    _employmentService.Update(existingEmployment);
                }
                else
                {
                    var newEmployment = Mapper.Map<EmploymentDto>(vm.PrimaryEmployer);
                    newEmployment.IsPrimary = true;
                    _employmentService.Create(newEmployment);
                }


                var existingPrevious = applicant.Employment.FirstOrDefault(x => x.IsPrimary == false);
                if (existingPrevious != null)
                {
                    Mapper.Map(vm.PreviousEmployer, existingPrevious);
                    _employmentService.Update(existingPrevious);
                }
                else
                {
                    var newEmployment = Mapper.Map<EmploymentDto>(vm.PreviousEmployer);
                    newEmployment.IsPrimary = false;
                    _employmentService.Create(newEmployment);
                }

                return RedirectToAction("VehicleInfo", "Vehicle");
            }
            return View();
        }
    }
}