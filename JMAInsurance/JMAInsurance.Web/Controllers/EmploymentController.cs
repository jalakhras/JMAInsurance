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
        public ActionResult EmploymentInfo(Employments employments)
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
                  
                    _employmentService.Update(existingEmployment);
                }
                else
                {
                    //vm.PrimaryEmployer
                    //var newEmployment = Mapper.Map<EmploymentDto>(employments.PrimaryEmployer);
                    var newEmployment = new EmploymentDto();
                    newEmployment.Employer = employments.PrimaryEmployer.Employer;
                    newEmployment.EmploymentType = employments.PrimaryEmployer.EmploymentType;
                    newEmployment.GrossMonthlyIncome = employments.PrimaryEmployer.GrossMonthlyIncome;
                    newEmployment.Position = employments.PrimaryEmployer.Position;
                    newEmployment.StartDate = employments.PrimaryEmployer.StartDate;
                    newEmployment.IsPrimary = true;
                    _employmentService.Create(newEmployment);
                }


                var existingPrevious = applicant.Employment.FirstOrDefault(x => x.IsPrimary == false);
                if (existingPrevious != null)
                {
                    //Mapper.Map(employments.PreviousEmployer, existingPrevious);
                    var newEmployment = new EmploymentDto();
                    newEmployment.Employer = employments.PreviousEmployer.Employer;
                    newEmployment.EmploymentType = employments.PreviousEmployer.EmploymentType;
                    newEmployment.GrossMonthlyIncome = employments.PreviousEmployer.GrossMonthlyIncome;
                    newEmployment.Position = employments.PreviousEmployer.Position;
                    newEmployment.StartDate = employments.PreviousEmployer.StartDate;
                    _employmentService.Update(existingPrevious);
                }
                else
                {
                    //var newEmployment = Mapper.Map<EmploymentDto>(employments.PreviousEmployer);
                    var newEmployment = new EmploymentDto();
                    newEmployment.Employer = employments.PreviousEmployer.Employer;
                    newEmployment.EmploymentType = employments.PreviousEmployer.EmploymentType;
                    newEmployment.GrossMonthlyIncome = employments.PreviousEmployer.GrossMonthlyIncome;
                    newEmployment.Position = employments.PreviousEmployer.Position;
                    newEmployment.StartDate = employments.PreviousEmployer.StartDate;
                    newEmployment.IsPrimary = false;
                    _employmentService.Create(newEmployment);
                }

                return RedirectToAction("VehicleInfo", "Vehicle");
            }
            return View();
        }
    }
}