using System.ComponentModel.DataAnnotations.Schema;

namespace JMAInsurance.Models.Dto
{
    public class MaritalStatus
    {
        public int Id { get; set; }
        public string StatusAr { get; set; }
        public string StatusEn { get; set; }
    }
}
