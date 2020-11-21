using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Keyless]
    [Table("Class_Teacher")]
    public partial class Class_Teacher
    {
        public int ClassId { get; set; }
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(ClassId))]
        public virtual Class Class { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public virtual Teacher Employee { get; set; }
    }
}
