using System.ComponentModel.DataAnnotations.Schema;

namespace JMAInsurance.Models.Dto
{

    public class Products
    {
        public int Id { get; set; }
        public double Liability { get; set; }
        public bool RoadSideAssistance { get; set; }
        public double PropertyDamage { get; set; }
        public double Collision { get; set; }
        public double Comprehensive { get; set; }
        public bool Rental { get; set; }
        public bool LoanPayoff { get; set; }
        public bool DriverRewards { get; set; }
        public int ApplicantId { get; set; }
        [ForeignKey("ApplicantId")]
        public virtual Applicant Applicant { get; set; }
    }
}