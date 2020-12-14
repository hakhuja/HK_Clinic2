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
        [Range(0,999999, ErrorMessage = "The range for the Building Number is 0 - 999999")]
        public int? BuildingNumber { get; set; }
        [Range(0, 999999, ErrorMessage = "The range for the Unit Number is 0 - 999999")]
        public int? UnitNumber { get; set; }
        [Required(ErrorMessage = "The Street Name field is required.")]
        public string StreetName { get; set; }
        [Range(00000, 99999, ErrorMessage = "Zip Code must contain 5 digits")]
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        [InverseProperty(nameof(Patient.Address))]
        public virtual ICollection<Patient> Patients { get; set; }
        [InverseProperty(nameof(Student_Parent.Address))]
        public virtual ICollection<Student_Parent> Student_Parents { get; set; }
    }
}
