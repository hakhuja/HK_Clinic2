using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("Treatment")]
    public partial class Treatment
    {
        public Treatment()
        {
            Prescriptions = new HashSet<Prescription>();
            Visits = new HashSet<Visit>();
        }

        [Key]
        public int TreatmentId { get; set; }
        public string Description { get; set; }

        [InverseProperty(nameof(Prescription.Treatment))]
        public virtual ICollection<Prescription> Prescriptions { get; set; }
        [InverseProperty(nameof(Visit.Treatment))]
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
