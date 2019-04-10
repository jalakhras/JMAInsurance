using JMAInsurance.Application.Service.Address;
using JMAInsurance.Application.Service.Applicants;
using JMAInsurance.Models.Dto;
using JMAInsurance.Web.ViewModels;
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
                    var newMainAddress = new AddressDto();
                    newMainAddress.Id = addressesVM.MainAddress.Id;
                    newMainAddress.IsMailing = addressesVM.MainAddress.IsMailing;
                    newMainAddress.ApplicantId = addressesVM.MainAddress.ApplicantId;
                    newMainAddress.City = addressesVM.MainAddress.City;
                    newMainAddress.Country = addressesVM.MainAddress.Country;
                    newMainAddress.State = addressesVM.MainAddress.State;
                    newMainAddress.StreetAddress = addressesVM.MainAddress.StreetAddress;
                    newMainAddress.Zip = addressesVM.MainAddress.Zip;
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
                    //var newMailingAddress = Mapper.Map<Address>(vm.MailingAddress);
                    addressesVM.MainAddress.IsMailing = false;
                    var newMailingAddress = new AddressDto();
                    newMailingAddress.Id = addressesVM.MainAddress.Id;
                    newMailingAddress.IsMailing = addressesVM.MainAddress.IsMailing;
                    newMailingAddress.ApplicantId = addressesVM.MainAddress.ApplicantId;
                    newMailingAddress.City = addressesVM.MainAddress.City;
                    newMailingAddress.Country = addressesVM.MainAddress.Country;
                    newMailingAddress.State = addressesVM.MainAddress.State;
                    newMailingAddress.StreetAddress = addressesVM.MainAddress.StreetAddress;
                    newMailingAddress.Zip = addressesVM.MainAddress.Zip;
                    applicant.Addresses.Add(newMailingAddress);
                }
                
                return RedirectToAction("EmploymentInfo", "Employment");
            }
            return View();
        }
    }
}