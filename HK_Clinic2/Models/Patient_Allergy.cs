using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("Patient_Allergy")]
    public partial class Patient_Allergy
    {
        [Key]
        public int PatientId { get; set; }
        [Key]
        public int AllergyId { get; set; }

        [ForeignKey(nameof(AllergyId))]
        [InverseProperty("Patient_Allergies")]
        public virtual Allergy Allergy { get; set; }
        [ForeignKey(nameof(PatientId))]
        [InverseProperty("Patient_Allergies")]
        public virtual Patient Patient { get; set; }
    }
}
