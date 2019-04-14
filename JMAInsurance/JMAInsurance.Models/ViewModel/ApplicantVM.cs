using JMAInsurance.Entity.Entity;
using JMAInsurance.Models.Infrastructure.CustomValidator;
using System;
using System.ComponentModel.DataAnnotations;

namespace JMAInsurance.Models.ViewModel
{
    public class ApplicantVM : LogDataVM
    {
        public string UserAgent { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public Guid ApplicantTracker { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        [BirthdateValidator]
        public DateTime? Dob { get; set; }
        [Required]
        public double? Phone { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Marital Status")]
        public string MaritalStatus { get; set; }
        [Required]
        [Display(Name = "Highest Education")]
        public string HighestEducation { get; set; }
        [Required]
        [Display(Name = "License Status")]
        public string LicenseStatus { get; set; }
        [Required]
        [Display(Name = "Years Licensed")]
        public string YearsLicensed { get; set; }
    }
}