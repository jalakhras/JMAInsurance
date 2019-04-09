using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMAInsurance.Entity.Security
{
    [SoftDelete]
    [Table("Security.UsersAccessLog")]
    public class UsersAccessLog
    {
        [Key]
        public int UsersAccessLogId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime AccessDate { get; set; }

    }
}
