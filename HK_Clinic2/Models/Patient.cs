using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("Patient")]
    public partial class Patient
    {
        public Patient()
        {
            External_Medical_Reports = new HashSet<External_Medical_Report>();
            Medical_Incident_Patients = new HashSet<Medical_Incident_Patient>();
            Patient_Allergies = new HashSet<Patient_Allergy>();
            Prescriptions = new HashSet<Prescription>();
            Visits = new HashSet<Visit>();
        }

        [Key]
        public int PatientId { get; set; }
        [Required(ErrorMessage = "The First Name field is required.")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "The Last Name field is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The Date of Birth field is required and must be a date.")]
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        [StringLength(10)]
        [Range(0000000000, 9999999999, ErrorMessage ="The Mobile field must contain 10 digits")]
        [RegularExpression("(05)(5|0|3|6|4|9|1|8|7)([0-9]{7})", ErrorMessage = "Wrong mobile number format. Ex. 05XXXXXXXX ")]
        public string Mobile { get; set; }
        [StringLength(50)]
        public string NationalId { get; set; }
        public int Gender { get; set; }
        public string Email { get; set; }
        [Required]
        public string Image { get; set; }
        public int? Language { get; set; }
        public int BloodType { get; set; }
        public bool? IsArchived { get; set; }
        public int LevelOfRisk { get; set; }
        public int Type { get; set; }
        public int AddressId { get; set; }
        public int? EmployeeId { get; set; }
        public int? StudentId { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Patients")]
        public virtual Address Address { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty("Patients")]
        public virtual Employee Employee { get; set; }
        [ForeignKey(nameof(StudentId))]
        [InverseProperty("Patients")]
        public virtual Student Student { get; set; }
        [InverseProperty(nameof(External_Medical_Report.Patient))]
        public virtual ICollection<External_Medical_Report> External_Medical_Reports { get; set; }
        [InverseProperty(nameof(Medical_Incident_Patient.Patient))]
        public virtual ICollection<Medical_Incident_Patient> Medical_Incident_Patients { get; set; }
        [InverseProperty(nameof(Patient_Allergy.Patient))]
        public virtual ICollection<Patient_Allergy> Patient_Allergies { get; set; }
        [InverseProperty(nameof(Prescription.Patient))]
        public virtual ICollection<Prescription> Prescriptions { get; set; }
        [InverseProperty(nameof(Visit.Patient))]
        public virtual ICollection<Visit> Visits { get; set; }
        //[InverseProperty(nameof(Appointment.Patient))]
        //public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
public enum PatientType
{
    Student = 1, Employee
}
public enum PatientGender
{
    Female = 1, Male
}

public enum PatientLanguage
{
    English = 1, Arabic, French
}
public enum PatientLevelOfRisk
{
    Low = 1, Medium, High
}
public enum PatientBloodType
{
    A = 1, B, AB, O
}