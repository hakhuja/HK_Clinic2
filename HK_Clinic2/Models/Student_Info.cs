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
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Image { get; set; }
        public int BloodType { get; set; }
        public int LevelOfRisk { get; set; }
        [Required]
        public string Expr1 { get; set; }
        [Required]
        public string Expr2 { get; set; }
        [Required]
        [StringLength(10)]
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int Class { get; set; }
        [Required]
        [StringLength(10)]
        public string FirstGuardianMobile { get; set; }
        [StringLength(10)]
        public string SecondGuardianMobile { get; set; }
        public int EducationLevel { get; set; }
        [Required]
        public string Expr3 { get; set; }
        [Required]
        public string Expr4 { get; set; }
        [Required]
        [StringLength(10)]
        public string Expr5 { get; set; }
        public string Expr6 { get; set; }
    }
}
