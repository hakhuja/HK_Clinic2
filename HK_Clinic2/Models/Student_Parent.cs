using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("Student_Parent")]
    public partial class Student_Parent
    {
        [Key]
        public int StudentId { get; set; }
        [Key]
        public int ParentId { get; set; }
        public int? AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Student_Parents")]
        public virtual Address Address { get; set; }
        [ForeignKey(nameof(ParentId))]
        [InverseProperty("Student_Parents")]
        public virtual Parent Parent { get; set; }
        [ForeignKey(nameof(StudentId))]
        [InverseProperty("Student_Parents")]
        public virtual Student Student { get; set; }
    }
}
