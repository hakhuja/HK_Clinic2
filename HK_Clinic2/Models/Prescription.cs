using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("Prescription")]
    public partial class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; }
        public DateTime date { get; set; }
        public int TreatmentId { get; set; }
        public int PatientId { get; set; }
        public int InventoryId { get; set; }

        [ForeignKey(nameof(InventoryId))]
        [InverseProperty("Prescriptions")]
        public virtual Inventory Inventory { get; set; }
        [ForeignKey(nameof(PatientId))]
        [InverseProperty("Prescriptions")]
        public virtual Patient Patient { get; set; }
        [ForeignKey(nameof(TreatmentId))]
        [InverseProperty("Prescriptions")]
        public virtual Treatment Treatment { get; set; }
    }
}
