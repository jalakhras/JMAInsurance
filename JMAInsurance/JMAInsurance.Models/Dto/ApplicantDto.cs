using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JMAInsurance.Models.Dto
{
    public class ApplicantDto
    {
        [Key]
        public int Id { get; set; }
        public Guid ApplicantTracker { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime? Dob { get; set; }
        public double? Phone { get; set; }
        [Required]
        public string Email { get; set; }
        //public int MaritalStatusId { get; set; }
        //[ForeignKey("MaritalStatusId")]
        //public virtual  MaritalStatusDto MaritalStatus { get; set; }
        public string MaritalStatus { get; set; }
        public string HighestEducation { get; set; }
        public string LicenseStatus { get; set; }
        public string YearsLicensed { get; set; }

        public virtual List<AddressDto> Addresses { get; set; }
        public virtual List<EmploymentDto> Employment { get; set; }
        public virtual List<VehicleDto> Vehicle { get; set; }
        public virtual List<ProductsDto> Products { get; set; }
        public int WorkFlowStage { get; set; }
    }
}