using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JMAInsurance.Models.Dto
{
    public class AddressDto
    {
        public int Id { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual CountryDto Country { get; set; }
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual CityDto City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public bool IsMailing { get; set; }
        public int ApplicantId { get; set; }
        [ForeignKey("ApplicantId")]
        public virtual ApplicantDto Applicant { get; set; }
    }
}