using JMAInsurance.Entity;
using JMAInsurance.EntityFramwork.DbContext;
using System;
using System.Web.Mvc;
using System.Net.Mail;
using System.Configuration;

namespace JMAInsurance.ApplicationShared.InfrastructureShared.ExceptionLoggingFilter
{
    public class ExceptionLoggingFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            //Send ajax response
            if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        Message = "An error has occured. Please try again later.",
                    }
                };
            }
            filterContext.HttpContext.Response.StatusCode = 500;
            //filterContext.ExceptionHandled = true; //if I uncommented this line the Applacation_Error() function in web.Global.asax.cs will be not exueted  

            //Log the error
            var _context = DependencyResolver.Current.GetService<JMAInsuranceDbContext>();
            var error = new ErrorLog()
            {
                Message = filterContext.Exception.Message,
                StackTrace = filterContext.Exception.StackTrace,
                ControllerName = filterContext.Controller.GetType().Name,
                TargetedResult = filterContext.Result.GetType().Name,
                SessionId = filterContext.HttpContext.Request["LoanId"],
                UserAgent = filterContext.HttpContext.Request.UserAgent,
                Timestamp = DateTime.Now
            };
            _context.Errors.Add(error);
            _context.SaveChanges();

            //Send an email notification
            MailMessage email = new MailMessage();

            email.From = new MailAddress("Jassar19942014@gmail.com");
            email.To.Add(new MailAddress(ConfigurationManager.AppSettings["ErrorEmail"]));
            email.Subject = "An error has occured";
            email.Body = filterContext.Exception.Message + Environment.NewLine
                + filterContext.Exception.StackTrace;
            SmtpClient client = new SmtpClient("localhost");
            //client.Send(email);
           

        }
    }
}
