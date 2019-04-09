using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JMAInsurance.Entity.Security
{
    [SoftDelete]
    [Table("Security.UserPermissions")]
    public class UserPermission : DomainBase
    {
        [Key]
        public int UserPermissionId { get; set; }
        public int? DepartmentId { get; set; }
        public int? NTP2InitiativeId { get; set; }
        public int? PortfolioId { get; set; }
        public int? ProjectId { get; set; }
        public int PermissionId { get; set; }

        public bool PreventInheritance { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        

    }
}
