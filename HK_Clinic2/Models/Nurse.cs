using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("Nurse")]
    public partial class Nurse
    {
        public Nurse()
        {
            Appointments = new HashSet<Appointment>();
            Event_Nurses = new HashSet<Event_Nurse>();
            Notification_Nurses = new HashSet<Notification_Nurse>();
        }

        [Key]
        public int EmployeeId { get; set; }
        public int ClinicId { get; set; }
        public int? UserId { get; set; }

        [ForeignKey(nameof(ClinicId))]
        [InverseProperty("Nurses")]
        public virtual Clinic Clinic { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty("Nurse")]
        public virtual Employee Employee { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Nurses")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(Appointment.Nurse))]
        public virtual ICollection<Appointment> Appointments { get; set; }
        [InverseProperty(nameof(Event_Nurse.Employee))]
        public virtual ICollection<Event_Nurse> Event_Nurses { get; set; }
        [InverseProperty(nameof(Notification_Nurse.Employee))]
        public virtual ICollection<Notification_Nurse> Notification_Nurses { get; set; }
    }
}
