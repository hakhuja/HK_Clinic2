using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Keyless]
    public partial class Student_Appointment
    {
        public int PatientId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int BloodType { get; set; }
        public int LevelOfRisk { get; set; }
        public int Class { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public string Reason { get; set; }
        public int Status { get; set; }
    }
}
