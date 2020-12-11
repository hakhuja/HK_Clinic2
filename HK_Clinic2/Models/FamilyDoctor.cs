using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("FamilyDoctor")]
    public partial class FamilyDoctor
    {
        [Key]
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "The First Name field is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The Last Name field is required.")]
        public string LastName { get; set; }
        [Required]
        [StringLength(10)]
        [Range(10, 10, ErrorMessage = "The Mobile field must contain 10 digits")]
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int StudentId { get; set; }

        [ForeignKey(nameof(StudentId))]
        [InverseProperty("FamilyDoctors")]
        public virtual Student Student { get; set; }
    }
}
