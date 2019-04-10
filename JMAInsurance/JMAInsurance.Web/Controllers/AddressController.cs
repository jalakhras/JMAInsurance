using JMAInsurance.Application.Service.Applicants;
using JMAInsurance.Models.Dto;
using JMAInsurance.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JMAInsurance.Web.Controllers
{
    public class AddressController : Controller
    {
        private readonly IApplicantService _applicantService; 
        public AddressController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }
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
    }
}