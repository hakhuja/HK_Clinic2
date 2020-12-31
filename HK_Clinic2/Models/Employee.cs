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
        [Required(ErrorMessage = "The Emergency Contact Number field is required.")]
        [StringLength(10)]
        [Range(0000000000, 9999999999, ErrorMessage = "The Mobile field must contain 10 digits")]
        [RegularExpression("(05)(5|0|3|6|4|9|1|8|7)([0-9]{7})", ErrorMessage = "Wrong mobile number format. Ex. 05XXXXXXXX ")]
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
public enum MaritalStatusEnum
{
    Single = 1, Married, Divorced, Widow, Other
}