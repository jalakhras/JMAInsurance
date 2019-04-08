﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JMAInsurance.Entity
{
    [Table("Country", Schema = "Lookups")]
    public class Country
    {
        public int Id { get; set; }
        [Required]
        public int NameAr { get; set; }
        public int NameEn { get; set; }
      
    }
}
