using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("Medical_Incident")]
    public partial class Medical_Incident
    {
        public Medical_Incident()
        {
            Medical_Incident_Patients = new HashSet<Medical_Incident_Patient>();
        }

        [Key]
        public int MedicalIncidentId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }

        [InverseProperty(nameof(Medical_Incident_Patient.MedicalIncident))]
        public virtual ICollection<Medical_Incident_Patient> Medical_Incident_Patients { get; set; }
    }
}
