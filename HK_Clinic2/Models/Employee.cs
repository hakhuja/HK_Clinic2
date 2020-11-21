using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("Employee")]
    public partial class Employee
    {
        public Employee()
        {
            Patients = new HashSet<Patient>();
        }

        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(10)]
        public string EmergencyContactNumber { get; set; }
        public int MaritalStatus { get; set; }

        [InverseProperty("Employee")]
        public virtual Nurse Nurse { get; set; }
        [InverseProperty("Employee")]
        public virtual Teacher Teacher { get; set; }
        [InverseProperty("Employee")]
        public virtual Staff Staff { get; set; }
        [InverseProperty(nameof(Patient.Employee))]
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
