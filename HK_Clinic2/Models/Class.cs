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
        [Required(ErrorMessage = "The Class Number field is required.")]
        [Range(0, 999999, ErrorMessage = "The range for the Class Number is 0 - 999999")]
        [StringLength(5)]
        public string ClassNumber { get; set; }
        [Required]
        [Range(0, 100, ErrorMessage = "The range for the Grade is 0 - 100")]
        public int Grade { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime Year { get; set; }

        [InverseProperty(nameof(Student.Class))]
        public virtual ICollection<Student> Students { get; set; }
    }
}
public enum GradeEnum
{
    KG1 = 1, KG2, KG3, Grade_1, Grade_2, Grade_3, Grade_4, Grade_5, Grade_6, Grade_7, Grade_8, Grade_9, Grade_10, Grade_11, Grade_12
}