using System.ComponentModel.DataAnnotations;

namespace JMAInsurance.Models.Dto
{
    public class Year
    {
        public int Id { get; set; }
        [Required]
        public double year { get; set; }
    }
}
