using JMAInsurance.Application.Service.Applicants;
using JMAInsurance.Models.ViewModel;
using System;
using System.Web.Mvc;

namespace JMAInsurance.Web.Controllers
{
    [OverrideAuthorization]
    public class HomeController : Controller
    {
        private readonly IApplicantService _applicantService;
        public HomeController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }
        public ActionResult Index()
        {
          
            ViewBag.Home = "true";
            return View();
        }
        public ActionResult Final()
        {
            Session.Clear();
            return View();
        }
        public ActionResult Clear()
        {
            Session.Clear();
            return View();
        }
        public ActionResult ProgressBar(int currentStage)
        {
            if (Session["Tracker"] != null)
            {
                Guid tracker = (Guid)Session["Tracker"];
                var Applicant = _applicantService.GetApplicantsByTraker(tracker);
                var highestStage = Applicant!=null ? Applicant.WorkFlowStage :0;
                return PartialView(new ProgressVM { CurrentStage = currentStage, HighestStage = highestStage });
            }
            else
                return PartialView(new ProgressVM { CurrentStage = 10, HighestStage = 10 });
            
        }

      

    }
}