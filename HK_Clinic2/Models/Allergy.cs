using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("Allergy")]
    public partial class Allergy
    {
        public Allergy()
        {
            Patient_Allergies = new HashSet<Patient_Allergy>();
        }

        [Key]
        public int AllergyId { get; set; }
        public int? Type { get; set; }
        public string Description { get; set; }

        [InverseProperty(nameof(Patient_Allergy.Allergy))]
        public virtual ICollection<Patient_Allergy> Patient_Allergies { get; set; }
    }
}
