using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JMAInsurance.Models.Dto
{
    [Table("Country", Schema = "Lookups")]
    public class CountryDto
    {
        public int Id { get; set; }
        [Required]
        public int NameAr { get; set; }
        public int NameEn { get; set; }
      
    }
}
