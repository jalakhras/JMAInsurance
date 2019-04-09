using System.Collections.Generic;

namespace JMAInsurance.Entity
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Errors = new List<ErrorMessage>();
        }
        public List<ErrorMessage> Errors { get; set; }
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
        public int TotalCounts { get; set; }
    }
}