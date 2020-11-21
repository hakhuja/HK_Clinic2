using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("Medical_Incident_Patient")]
    public partial class Medical_Incident_Patient
    {
        [Key]
        public int PatientId { get; set; }
        [Key]
        public int MedicalIncidentId { get; set; }
        public string Note { get; set; }
        public bool Answer { get; set; }

        [ForeignKey(nameof(MedicalIncidentId))]
        [InverseProperty(nameof(Medical_Incident.Medical_Incident_Patients))]
        public virtual Medical_Incident MedicalIncident { get; set; }
        [ForeignKey(nameof(PatientId))]
        [InverseProperty("Medical_Incident_Patients")]
        public virtual Patient Patient { get; set; }
    }
}
