using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("Notification")]
    public partial class Notification
    {
        public Notification()
        {
            Notification_Nurses = new HashSet<Notification_Nurse>();
            Notification_Parents = new HashSet<Notification_Parent>();
            Visits = new HashSet<Visit>();
        }

        [Key]
        public int NotificationId { get; set; }
        [Required]
        public string Title { get; set; }
        public int? Type { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public DateTime NotificationDateTime { get; set; }
        public int Medium { get; set; }
        public string Content { get; set; }
        public int? AppointmentId { get; set; }
        public int? InventoryId { get; set; }

        [ForeignKey(nameof(AppointmentId))]
        [InverseProperty("Notifications")]
        public virtual Appointment Appointment { get; set; }
        [ForeignKey(nameof(InventoryId))]
        [InverseProperty("Notifications")]
        public virtual Inventory Inventory { get; set; }
        [InverseProperty(nameof(Notification_Nurse.Notification))]
        public virtual ICollection<Notification_Nurse> Notification_Nurses { get; set; }
        [InverseProperty(nameof(Notification_Parent.Notification))]
        public virtual ICollection<Notification_Parent> Notification_Parents { get; set; }
        [InverseProperty(nameof(Visit.Notification))]
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
