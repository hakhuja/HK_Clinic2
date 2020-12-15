using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Keyless]
    public partial class Student_Info
    {
        public int PatientId { get; set; }
        [Required(ErrorMessage = "The First Name field is required.")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "The Last Name field is required.")]
        public string LastName { get; set; }
        [Required]
        public string Image { get; set; }
        public int BloodType { get; set; }
        public int LevelOfRisk { get; set; }
        [Required]
        [StringLength(10)]
        [Range(0000000000, 9999999999, ErrorMessage = "The Mobile field must contain 10 digits")]
        public string Mobile { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int ClassNumber { get; set; }
        [Required]
        [StringLength(10)]
        [Range(000000000, 9999999999, ErrorMessage = "The First Gurdian Mobile field must contain 10 digits")]
        public string FirstGuardianMobile { get; set; }
        public int EducationLevel { get; set; }
    }
}
