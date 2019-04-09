using JMAInsurance.Entity.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JMAInsurance.Entity.Security
{
    [SoftDelete]
    [Table("Security.Permissions")]
    public class Permission : DomainBase
    {
        [Key]
        public int PermissionId { get; set; }

        [Required]
        [StringLength(250)]
        public string ModuleCode { get; set; }

        [Required]
        [StringLength(250)]
        public string PermissionArabicName { get; set; }
        [Required]
        [StringLength(250)]
        public string PermissionEnglishName { get; set; }
        [NotMapped]
        public string PermissionName
        {
            get
            {
                switch (SessionManager.Current.CurrentLanguage)
                {
                    case enum_Language.English:
                        return PermissionEnglishName;
                    case enum_Language.Arabic:
                    default:
                        return PermissionArabicName;
                }
            }
        }

    }
}
