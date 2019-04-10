using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JMAInsurance.Entity
{
    [Table("Address", Schema = "Insurance")]
    public class Address
    {
        public int Id { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public bool IsMailing { get; set; }
        public int ApplicantId { get; set; }
        [ForeignKey("ApplicantId")]
        public virtual Applicant Applicant { get; set; }

        //public int CountryId { get; set; }
        //[ForeignKey("CountryId")]
        //public virtual Country Country { get; set; }
        //public int CityId { get; set; }
        //[ForeignKey("CityId")]
        //public virtual City City { get; set; }
    }
}