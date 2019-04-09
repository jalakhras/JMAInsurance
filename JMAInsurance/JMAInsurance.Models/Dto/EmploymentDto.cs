using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JMAInsurance.Models.Dto
{
    public class EmploymentDto
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
        public virtual ApplicantDto Applicant { get; set; }
    }
}