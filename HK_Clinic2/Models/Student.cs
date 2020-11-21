using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("Student")]
    public partial class Student
    {
        public Student()
        {
            FamilyDoctors = new HashSet<FamilyDoctor>();
            Patients = new HashSet<Patient>();
            Student_Parents = new HashSet<Student_Parent>();
        }

        [Key]
        public int StudentId { get; set; }
        public int EducationLevel { get; set; }
        public int? ClassId { get; set; }

        [ForeignKey(nameof(ClassId))]
        [InverseProperty("Students")]
        public virtual Class Class { get; set; }
        [InverseProperty(nameof(FamilyDoctor.Student))]
        public virtual ICollection<FamilyDoctor> FamilyDoctors { get; set; }
        [InverseProperty(nameof(Patient.Student))]
        public virtual ICollection<Patient> Patients { get; set; }
        [InverseProperty(nameof(Student_Parent.Student))]
        public virtual ICollection<Student_Parent> Student_Parents { get; set; }
    }
}
