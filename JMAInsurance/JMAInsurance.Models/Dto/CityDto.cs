using System.ComponentModel.DataAnnotations.Schema;

namespace JMAInsurance.Models.Dto
{
    public class CityDto
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual CountryDto Country { get; set; }
    }
}
