using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("Notification_Nurse")]
    public partial class Notification_Nurse
    {
        [Key]
        public int NotificationId { get; set; }
        [Key]
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(Nurse.Notification_Nurses))]
        public virtual Nurse Employee { get; set; }
        [ForeignKey(nameof(NotificationId))]
        [InverseProperty("Notification_Nurses")]
        public virtual Notification Notification { get; set; }
    }
}
