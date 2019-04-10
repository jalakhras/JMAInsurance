using AutoMapper;
using JMAInsurance.Application.Service.Address;
using JMAInsurance.Application.Service.Applicants;
using JMAInsurance.Models.Dto;
using JMAInsurance.Models.ViewModel;
using System;
using System.Linq;
using System.Web.Mvc;

namespace JMAInsurance.Web.Controllers
{
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
            if (Session["Tracker"] == null)
            {
                return RedirectToAction("ApplicantInfo", "Applicant");
            }
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
                   
                    _addressService.Update(existingMain);
                }
                else
                {
                    addressesVM.MainAddress.IsMailing = false;
                    var newMainAddress = Mapper.Map<AddressDto>(addressesVM.MainAddress);
                    applicant.Addresses.Add(newMainAddress);
                }

                //Check if mailing address already exists, if so update it
                var existingMailing = _addressService.GetAddressbyApplicantId(applicant.Id, true);
                if (existingMailing != null)
                {
                    _addressService.Update(existingMailing);
                }
                else
                {
                    addressesVM.MailingAddress.IsMailing = true;
                    var newMailingAddress = Mapper.Map<AddressDto>(addressesVM.MainAddress);
                    addressesVM.MainAddress.IsMailing = false;
                    applicant.Addresses.Add(newMailingAddress);
                }
                return RedirectToAction("EmploymentInfo", "Employment");
            }
            return View();
        }
    }
}