using System.ComponentModel.DataAnnotations.Schema;

namespace JMAInsurance.Models.Dto
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int YearId  { get; set; }
        [ForeignKey("YearId")]
        public virtual Year Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string BodyType { get; set; }
        public string PrimaryUse { get; set; }
        public string OwnLease { get; set; }
        [ForeignKey("Applicant")]
        public int ApplicantId { get; set; }
        public virtual Applicant Applicant { get; set; }
    }
}