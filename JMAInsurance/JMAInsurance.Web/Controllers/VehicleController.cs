using AutoMapper;
using JMAInsurance.Application.Service.Applicants;
using JMAInsurance.Application.Service.Vehicle;
using JMAInsurance.ApplicationShared.InfrastructureShared.ActionFilter;
using JMAInsurance.Models.ViewModel;
using System;
using System.Linq;
using System.Web.Mvc;

namespace JMAInsurance.Web.Controllers
{
    [WorkflowFilter( MinRequiredStage = (int)WorkflowValues.EmploymentInfo, CurrentStage = (int)WorkflowValues.VehicleInfo)]
    public class VehicleController : Controller
    {
        private readonly IApplicantService _applicantService;
        private readonly IVehicleService _vehicleService;
        public VehicleController(IApplicantService applicantService, IVehicleService vehicleService)
        {
            _applicantService = applicantService;
            _vehicleService = vehicleService;
        }
        public ActionResult VehicleInfo()
        {
           
            var tracker = (Guid)Session["Tracker"];

            var vehicle = new VehicleVM();
            var existingVehicle = _applicantService.GetApplicantsByTraker(tracker)?.Vehicle.FirstOrDefault();
            if (existingVehicle != null)
            {
                vehicle = Mapper.Map<VehicleVM>(existingVehicle);
            }

            return View(vehicle);
        }

        [HttpPost]
        public ActionResult VehicleInfo(VehicleVM vehicleVM)
        {
            if (Session["Tracker"] == null)
            {
                return RedirectToAction("ApplicantInfo", "Applicant");
            }
            var tracker = (Guid)Session["Tracker"];

            if (ModelState.IsValid)
            {
                var applicant = _applicantService.GetApplicantsByTraker(tracker);

                var existingVehicle = applicant.Vehicle.FirstOrDefault();
                if (existingVehicle != null)
                {
                   var vehicleDto =  Mapper.Map(vehicleVM, existingVehicle);
                    _vehicleService.Update(vehicleDto);
                }
                else
                {
                  var vehicle =   Mapper.Map(vehicleVM, existingVehicle);
                    applicant.Vehicle.Add(vehicle);
                }

               
                return RedirectToAction("ProductInfo", "Products");
            }

            return View();
        }
    }
}