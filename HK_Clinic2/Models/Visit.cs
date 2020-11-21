using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("Visit")]
    public partial class Visit
    {
        public Visit()
        {
            Sick_Leaves = new HashSet<Sick_Leave>();
            Vitals = new HashSet<Vital>();
        }

        [Key]
        public int VisitId { get; set; }
        public DateTime VisitDateTime { get; set; }
        [Required]
        public string Assessment { get; set; }
        public int Status { get; set; }
        public string Note { get; set; }
        public int PatientId { get; set; }
        public int? NotificationId { get; set; }
        public int AppointmentId { get; set; }
        public int TreatmentId { get; set; }
        public int? InventoryId { get; set; }

        [ForeignKey(nameof(AppointmentId))]
        [InverseProperty("Visits")]
        public virtual Appointment Appointment { get; set; }
        [ForeignKey(nameof(InventoryId))]
        [InverseProperty("Visits")]
        public virtual Inventory Inventory { get; set; }
        [ForeignKey(nameof(NotificationId))]
        [InverseProperty("Visits")]
        public virtual Notification Notification { get; set; }
        [ForeignKey(nameof(PatientId))]
        [InverseProperty("Visits")]
        public virtual Patient Patient { get; set; }
        [ForeignKey(nameof(TreatmentId))]
        [InverseProperty("Visits")]
        public virtual Treatment Treatment { get; set; }
        [InverseProperty(nameof(Sick_Leave.Visit))]
        public virtual ICollection<Sick_Leave> Sick_Leaves { get; set; }
        [InverseProperty(nameof(Vital.Visit))]
        public virtual ICollection<Vital> Vitals { get; set; }
    }
}
