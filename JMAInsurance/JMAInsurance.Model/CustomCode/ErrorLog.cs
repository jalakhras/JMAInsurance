using System;
using System.IO;

namespace JMAInsurance.Entity
{
    public enum ErrorType
    {
        Error = 1,
        Info = 2,
        Warning = 3,
    }
    public static class ErrorLog
    {
        public static void Log(ErrorType type, Exception exception)
        {
            if (type == ErrorType.Error)
            {
                Exception ex = GetInnerException(exception);
            }
            else if (type == ErrorType.Info)
            {
                Exception ex = GetInnerException(exception);
                Elmah.Error error = new Elmah.Error(ex);
                error.Type = "Information";
            }
            else if (type == ErrorType.Warning)
            {
                Exception ex = GetInnerException(exception);
                Elmah.Error error = new Elmah.Error(ex);
                error.Type = "Warning";
            }
        }

        private static Exception GetInnerException(Exception ex)
        {
            Elmah.ErrorLog.GetDefault(System.Web.HttpContext.Current).Log(new Elmah.Error(ex));

            if (ex.InnerException == null)
                return ex;
            else
                return GetInnerException(ex.InnerException);
        }
        public static string GetExceptionMessage(Exception ex)
        {
            ex = GetInnerException(ex);

            return ex.Message;
        }
    }


    public static class WebApiErrorLog
    {
        public static void Log(ErrorType type, Exception exception)
        {
            if (type == ErrorType.Error)
            {
                Exception ex = GetInnerException(exception);
            }
            else if (type == ErrorType.Info)
            {
                Exception ex = GetInnerException(exception);
                Elmah.Error error = new Elmah.Error(ex);
                error.Type = "Information";
            }
            else if (type == ErrorType.Warning)
            {
                Exception ex = GetInnerException(exception);
                Elmah.Error error = new Elmah.Error(ex);
                error.Type = "Warning";
            }
        }

        private static Exception GetInnerException(Exception ex)
        {
            File.AppendAllText(System.Web.HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["LogFiles"]) + "\\" 
                + DateTime.Now.ToString("ddMMyyyy") + ".txt" , "Exception: " + ex.Message + Environment.NewLine + "StackTrace: " + ex.StackTrace + Environment.NewLine + Environment.NewLine);

            if (ex.InnerException == null)
                return ex;
            else
                return GetInnerException(ex.InnerException);
        }
        public static string GetExceptionMessage(Exception ex)
        {
            ex = GetInnerException(ex);

            return ex.Message;
        }
    }
}
