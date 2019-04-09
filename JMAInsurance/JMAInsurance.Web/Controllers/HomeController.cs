using JMAInsurance.Application.Service;
using System.Web.Mvc;

namespace JMAInsurance.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApplicantService _applicantService;
      

        public HomeController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }
        public ActionResult Index()
        {
            _applicantService.GetAll();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}