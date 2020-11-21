using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("Class")]
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }

        [Key]
        public int ClassId { get; set; }
        [Required]
        [StringLength(5)]
        public string ClassNumber { get; set; }
        public int Grade { get; set; }
        [Column(TypeName = "date")]
        public DateTime Year { get; set; }

        [InverseProperty(nameof(Student.Class))]
        public virtual ICollection<Student> Students { get; set; }
    }
}
