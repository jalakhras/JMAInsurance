using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JMAInsurance.Entity
{
    [Table("Employments", Schema = "Insurance")]
    public class Employment
    {
        public int Id { get; set; }
        public string EmploymentType { get; set; }
        public string Employer { get; set; }
        public string Position { get; set; }
        public double GrossMonthlyIncome { get; set; }
        public DateTime? StartDate { get; set; }
        public bool IsPrimary { get; set; }
        public int ApplicantId { get; set; }
        [ForeignKey("ApplicantId")]
        public virtual Applicant Applicant { get; set; }
    }
}