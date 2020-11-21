using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("Address")]
    public partial class Address
    {
        public Address()
        {
            Patients = new HashSet<Patient>();
            Student_Parents = new HashSet<Student_Parent>();
        }

        [Key]
        public int AddressId { get; set; }
        public int? BuildingNumber { get; set; }
        public int? UnitNumber { get; set; }
        [Required]
        public string StreetName { get; set; }
        [StringLength(5)]
        public string ZipCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }

        [InverseProperty(nameof(Patient.Address))]
        public virtual ICollection<Patient> Patients { get; set; }
        [InverseProperty(nameof(Student_Parent.Address))]
        public virtual ICollection<Student_Parent> Student_Parents { get; set; }
    }
}
