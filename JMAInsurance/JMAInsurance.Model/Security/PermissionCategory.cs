using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JMAInsurance.Entity.Security
{
    [Table("Security.PermissionCategories")]
    public class PermissionCategory
    {
        [Key]
        public int Id { get; set; }
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }
    }
}
