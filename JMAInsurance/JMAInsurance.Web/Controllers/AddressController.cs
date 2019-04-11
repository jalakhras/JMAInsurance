using AutoMapper;
using JMAInsurance.Application.Service.Address;
using JMAInsurance.Application.Service.Applicants;
using JMAInsurance.ApplicationShared.InfrastructureShared.ActionFilter;
using JMAInsurance.Models.Dto;
using JMAInsurance.Models.ViewModel;
using System;
using System.Linq;
using System.Web.Mvc;

namespace JMAInsurance.Web.Controllers
{
    [WorkflowFilter(MinRequiredStage = (int)WorkflowValues.ApplicantInfo, CurrentStage = (int)WorkflowValues.AddressInfo)]
    public class AddressController : Controller
    {
        private readonly IApplicantService _applicantService; 
        private readonly IAddressService _addressService; 
        public AddressController(IApplicantService applicantService, IAddressService addressService)
        {
            _applicantService = applicantService;
            _addressService = addressService;
        }
        [HttpGet]
        public ActionResult AddressInfo()
        {
           
            var tracker = (Guid)Session["Tracker"];
            var addresses = new AddressesVM();
            var applicant = _applicantService.GetApplicantsByTraker(tracker);
            var existingMain = applicant?.Addresses?.FirstOrDefault(x => x.IsMailing == false);
            var existingMailing = applicant?.Addresses?.FirstOrDefault(x => x.IsMailing == true);
            addresses.MainAddress = existingMain ?? null;
            addresses.MailingAddress = existingMailing ?? null;
            return View(addresses);


        }

        [HttpPost]
        public ActionResult AddressInfo(AddressesVM addressesVM)
        {
            if (Session["Tracker"] == null)
            {
                return RedirectToAction("ApplicantInfo", "Applicant");
            }
            var tracker = (Guid)Session["Tracker"];

            if (ModelState.IsValid)
            {
                var applicant = _applicantService.GetApplicantsByTraker(tracker);

                //Check if main address already exists, if so update it
                var existingMain = _addressService.GetAddressbyApplicantId(applicant.Id, false);

                if (existingMain != null)
                {
                   var existingMainToUpdate = Mapper.Map<AddressDto>(addressesVM.MainAddress);
                    if(existingMainToUpdate != existingMain)
                    _addressService.Update(existingMainToUpdate);
                }
                else
                {
                    addressesVM.MainAddress.IsMailing = false;
                    var newMainAddress = Mapper.Map<AddressDto>(addressesVM.MainAddress);
                    applicant.Addresses.Add(newMainAddress);
                    newMainAddress.ApplicantId = applicant.Id;

                    _addressService.Create(newMainAddress);


                }

                //Check if mailing address already exists, if so update it
                var existingMailing = _addressService.GetAddressbyApplicantId(applicant.Id, true);
                if (existingMailing != null)
                {
                   var  existingMailingToUpdate =  Mapper.Map<AddressDto>(addressesVM.MailingAddress);
                    if(existingMailingToUpdate !=existingMailing)
                    _addressService.Update(existingMailingToUpdate);
                }
                else
                {
                    addressesVM.MailingAddress.IsMailing = true;
                    addressesVM.MailingAddress.ApplicantId = applicant.Id;
                    var newMailingAddress = Mapper.Map<AddressDto>(addressesVM.MainAddress);
                    addressesVM.MainAddress.IsMailing = false;
                    addressesVM.MainAddress.ApplicantId = applicant.Id;
                    applicant.Addresses.Add(newMailingAddress);
                    _addressService.Create(newMailingAddress);

                }
                return RedirectToAction("EmploymentInfo", "Employment");
            }
            return View();
        }
    }
}