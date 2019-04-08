using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JMAInsurance.Entity
{
    [Table("Years", Schema = "Lookups")]
    public class Year
    {
        public int Id { get; set; }
        [Required]
        public double year { get; set; }
    }
}
