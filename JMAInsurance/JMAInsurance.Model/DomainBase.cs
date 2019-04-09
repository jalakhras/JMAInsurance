using JMAInsurance.Entity.Security;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JMAInsurance.Entity
{
    public class DomainBase
    {

        [ForeignKey("CreatedBy")]
        public int? CreatedById { get; set; }
        [ForeignKey("CreatedById")]
        public virtual User CreatedBy { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime CreatedOn { get; set; }
        [ForeignKey("ModifiedBy")]
        public int? ModifiedById { get; set; }
        [ForeignKey("ModifiedById")]
        public virtual User ModifiedBy { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        
    }
}
