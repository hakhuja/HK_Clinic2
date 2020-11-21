using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("Clinic")]
    public partial class Clinic
    {
        public Clinic()
        {
            Nurses = new HashSet<Nurse>();
        }

        [Key]
        public int ClinicId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Status { get; set; }

        [InverseProperty(nameof(Nurse.Clinic))]
        public virtual ICollection<Nurse> Nurses { get; set; }
    }
}
