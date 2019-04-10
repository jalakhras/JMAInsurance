using JMAInsurance.Application.Service.Applicants;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JMAInsurance.Web.Infrastructure
{

    public class WorkflowFilter : FilterAttribute, IActionFilter
    {
        private readonly IApplicantService _applicantService;
        public WorkflowFilter(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

      

        private int _highestCompletedStage;
        public int MinRequiredStage { get; set; }
        public int CurrentStage { get; set; }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var applicantId = filterContext.HttpContext.Session["Tracker"];
            if (applicantId != null)
            {
                Guid tracker;
                if (Guid.TryParse(applicantId.ToString(), out tracker))
                {
                    var applicant = _applicantService.GetApplicantsByTraker(tracker);
                    _highestCompletedStage = (applicant != null) ? applicant.WorkFlowStage : 0;
                    if (MinRequiredStage > _highestCompletedStage)
                    {

                        switch (_highestCompletedStage)
                        {
                            case (int)WorkflowValues.ApplicantInfo:
                                filterContext.Result = GenerateRedirectUrl("ApplicantInfo", "Applicant");
                                break;

                            case (int)WorkflowValues.AddressInfo:
                                filterContext.Result = GenerateRedirectUrl("AddressInfo", "Address");
                                break;

                            case (int)WorkflowValues.EmploymentInfo:
                                filterContext.Result = GenerateRedirectUrl("EmploymentInfo", "Employment");
                                break;

                            case (int)WorkflowValues.VehicleInfo:
                                filterContext.Result = GenerateRedirectUrl("VehicleInfo", "Vehicle");
                                break;

                            case (int)WorkflowValues.Products:
                                filterContext.Result = GenerateRedirectUrl("ProductInfo", "Products");
                                break;
                        }
                    }
                }
            }
            else
            {
                if (CurrentStage != (int)WorkflowValues.ApplicantInfo)
                {
                    filterContext.Result = GenerateRedirectUrl("ApplicantInfo", "Applicant");
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var sessionId = HttpContext.Current.Session["Tracker"];
            if (sessionId != null)
            {
                Guid tracker;
                if (Guid.TryParse(sessionId.ToString(), out tracker))
                {
                    if (filterContext.HttpContext.Request.RequestType == "POST" && CurrentStage >= _highestCompletedStage)
                    {
                        var applicantDto = _applicantService.GetApplicantsByTraker(tracker);
                        _applicantService.UpdateWorkFlowStage(applicantDto, CurrentStage);
                    }
                }
            }
        }

        private RedirectToRouteResult GenerateRedirectUrl(string action, string controller)
        {
            return new RedirectToRouteResult(new RouteValueDictionary(new { action = action, controller = controller }));
        }

    }
}