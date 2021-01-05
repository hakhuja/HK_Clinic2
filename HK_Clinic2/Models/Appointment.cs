using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("Appointment")]
    public partial class Appointment
    {
        public Appointment()
        {
            Notifications = new HashSet<Notification>();
            Visits = new HashSet<Visit>();
        }

        [Key]
        public int AppointmentId { get; set; }
        [Required(ErrorMessage = "The Appointment Date & Time field is required.")]
        public DateTime AppointmentDateTime { get; set; }
        public string Reason { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public int TeacherId { get; set; }
        public int NurseId { get; set; }
        //public int PatientId { get; set; }


        [ForeignKey(nameof(NurseId))]
        [InverseProperty("Appointments")]
        public virtual Nurse Nurse { get; set; }
        [ForeignKey(nameof(TeacherId))]
        [InverseProperty("Appointments")]
        public virtual Teacher Teacher { get; set; }
        //[ForeignKey(nameof(PatientId))]
        //[InverseProperty("Appointments")]
        //public virtual Patient Patient { get; set; }
        [InverseProperty(nameof(Notification.Appointment))]
        public virtual ICollection<Notification> Notifications { get; set; }
        [InverseProperty(nameof(Visit.Appointment))]
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
public enum AppointmentStatusEnum
{
    Confirmed = 1, Pending, Canceled
}