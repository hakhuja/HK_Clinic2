using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("Notification_Parent")]
    public partial class Notification_Parent
    {
        [Key]
        public int NotificationId { get; set; }
        [Key]
        public int ParentId { get; set; }

        [ForeignKey(nameof(NotificationId))]
        [InverseProperty("Notification_Parents")]
        public virtual Notification Notification { get; set; }
        [ForeignKey(nameof(ParentId))]
        [InverseProperty("Notification_Parents")]
        public virtual Parent Parent { get; set; }
    }
}
