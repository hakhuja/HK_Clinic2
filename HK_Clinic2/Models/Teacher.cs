using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("Teacher")]
    public partial class Teacher
    {
        public Teacher()
        {
            Appointments = new HashSet<Appointment>();
        }

        [Key]
        public int EmployeeId { get; set; }
        public int? UserId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty("Teacher")]
        public virtual Employee Employee { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Teachers")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(Appointment.Teacher))]
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
