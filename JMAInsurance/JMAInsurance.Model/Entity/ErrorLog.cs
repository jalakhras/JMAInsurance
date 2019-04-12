using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JMAInsurance.Entity
{
    [Table("Errors", Schema = "common")]

    public class ErrorLog
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string ControllerName { get; set; }
        public string UserAgent { get; set; }
        public string StackTrace { get; set; }
        public string SessionId { get; set; }
        public string TargetedResult { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
