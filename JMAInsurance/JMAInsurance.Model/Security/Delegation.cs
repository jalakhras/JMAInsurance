using JMAInsurance.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JMAInsurance.Entity.Security
{
    [SoftDelete]
    [Table("Security.Delegations")]
    public class Delegation : DomainBase
    {
        [Key]
        public int DelegationId { get; set; }

        public int? FromUserId { get; set; }
        [ForeignKey("FromUserId")]
        public virtual User FromUser { get; set; }

        public int? ToUserId { get; set; }
        [ForeignKey("ToUserId")]
        public virtual User ToUser { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }



    }
}
