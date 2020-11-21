using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("Event_Nurse")]
    public partial class Event_Nurse
    {
        [Key]
        public int EventId { get; set; }
        [Key]
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(Nurse.Event_Nurses))]
        public virtual Nurse Employee { get; set; }
        [ForeignKey(nameof(EventId))]
        [InverseProperty("Event_Nurses")]
        public virtual Event Event { get; set; }
    }
}
