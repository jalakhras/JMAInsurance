﻿using AutoMapper;
using JMAInsurance.Application.Service.Applicants;
using JMAInsurance.Application.Service.Vehicle;
using JMAInsurance.Models.Dto;
using JMAInsurance.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace JMAInsurance.Web.Controllers
{
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
            if (Session["Tracker"] == null)
            {
                return RedirectToAction("ApplicantInfo", "Applicant");
            }
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
                   var x =  Mapper.Map(vehicleVM, existingVehicle);
                    //_context.Entry(existingVehicle).State = EntityState.Modified;
                    _vehicleService.Update(Mapper.Map(vehicleVM, existingVehicle));
                }
                else
                {
                    var vehicle = new VehicleDto();
                    vehicle.BodyType = vehicleVM.BodyType;
                    vehicle.Make = vehicleVM.Make;
                    vehicle.Model = vehicleVM.Model;
                    vehicle.OwnLease = vehicleVM.OwnLease;
                    vehicle.PrimaryUse = vehicleVM.PrimaryUse;
                    vehicle.Year = vehicleVM.Year;
                    applicant.Vehicle.Add(vehicle);
                }

               
                return RedirectToAction("ProductInfo", "Products");
            }

            return View();
        }
    }
}