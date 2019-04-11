using AutoMapper;
using JMAInsurance.Application.Service.Applicants;
using JMAInsurance.Application.Service.Employments;
using JMAInsurance.ApplicationShared.InfrastructureShared.ActionFilter;
using JMAInsurance.Models.Dto;
using JMAInsurance.Models.ViewModel;
using System;
using System.Linq;
using System.Web.Mvc;

namespace JMAInsurance.Web.Controllers
{
    [WorkflowFilter(MinRequiredStage = (int)WorkflowValues.AddressInfo,CurrentStage = (int)WorkflowValues.EmploymentInfo)]
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
                    var newEmployment = Mapper.Map<EmploymentDto>(employments.PrimaryEmployer);
                    newEmployment.IsPrimary = true;
                    _employmentService.Create(newEmployment);
                }


                var existingPrevious = applicant.Employment.FirstOrDefault(x => x.IsPrimary == false);
                if (existingPrevious != null)
                {
                   var newEmployment= Mapper.Map(employments.PreviousEmployer, existingPrevious);
                    _employmentService.Update(existingPrevious);
                }
                else
                {
                    var newEmployment = Mapper.Map<EmploymentDto>(employments.PreviousEmployer);
                    newEmployment.IsPrimary = false;
                    _employmentService.Create(newEmployment);
                }

                return RedirectToAction("VehicleInfo", "Vehicle");
            }
            return View();
        }
    }
}