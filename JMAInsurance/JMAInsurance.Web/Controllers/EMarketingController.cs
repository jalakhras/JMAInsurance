using JMAInsurance.Application.Service.IEReport;
using JMAInsurance.Models.Dto;
using System.Web.Mvc;

namespace JMAInsurance.Web.Controllers
{
    public class EMarketingController : Controller
    {
        private readonly IEMonthlyReportService _eMonthlyReportService;
        private readonly IEWeeklyReportService _eWeeklyReportService;
        public EMarketingController(IEMonthlyReportService eMonthlyReportService, IEWeeklyReportService eWeeklyReportService)
        {
            _eMonthlyReportService = eMonthlyReportService;
            _eWeeklyReportService = eWeeklyReportService;
        }
        /// <summary>
        /// In my Applcation dose not contant UI to generate report 
        /// you can user Fiddler to call this Action methods 
        /// 
        /// this is requsit Body
        //<EWeeklyReportDto>
        //<NumberRead>100</NumberRead>
        //<ClickThruRate>3.5</ClickThruRate>
        //<NumberSent>2700</NumberSent>
        //<AverageQuote>117</AverageQuote>
        //<ProjectedConversationRate>2.1</ProjectedConversationRate>
        //</EWeeklyReportDto>

        /// </summary>
        /// <param name="weeklyReportDto"></param>
        /// <returns></returns>
        public ActionResult WeeklyReport(EWeeklyReportDto weeklyReportDto)
        {
            if (ModelState.IsValid)
            {
                _eWeeklyReportService.Create(weeklyReportDto);
                return Content("OK");
            }

            return Content("Error");
        }
        /// <summary>
        /// In my Applcation dose not contant UI to generate report 
        /// you can user Fiddler to call this Action methods 
        /// 
        /// this is requsit Body
        //<EMonthlyReportDto>
        //<NumberRead>100</NumberRead>
        //<ClickThruRate>3.5</ClickThruRate>
        //<NumberSent>2700</NumberSent>
        //<AverageQuote>117</AverageQuote>
        //<ProjectedConversationRate>2.1</ProjectedConversationRate>
        //</EMonthlyReportDto>
        /// </summary>
        /// <param name="monthlyReportDto"></param>
        /// <returns></returns>
        public ActionResult MonthlyReport(EMonthlyReportDto monthlyReportDto)
        {
            if (ModelState.IsValid)
            {
                _eMonthlyReportService.Create(monthlyReportDto);
                return Content("OK");
            }

            return Content("Error");
        }




        #region I refictoring this code by Create custom XMLModelBinder : Jass
        //public ActionResult WeeklyReport()
        //{
        //    var serializer = new XmlSerializer(typeof(EWeeklyReportDto));

        //    var report = (EWeeklyReportDto)serializer.Deserialize(HttpContext.Request.InputStream);
        //    _eWeeklyReportService.Create(report); 


        //    return new EmptyResult();
        //}
        //public ActionResult MonthlyReport()
        //{
        //    var serializer = new XmlSerializer(typeof(EMonthlyReportDto));

        //    var report = (EMonthlyReportDto)serializer.Deserialize(HttpContext.Request.InputStream);
        //    _eMonthlyReportService.Create(report); 
        //    return new EmptyResult();
        //}
        #endregion
    }
}