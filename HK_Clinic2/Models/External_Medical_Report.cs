using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("External_Medical_Report")]
    public partial class External_Medical_Report
    {
        [Key]
        public int ExternalMedicalReportId { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AttachmentDateTime { get; set; }
        [Column(TypeName = "date")]
        public DateTime MedicalReportDate { get; set; }
        [Required(ErrorMessage = "The Scanned File field is required.")]
        public string ScannedFile { get; set; }
        public int PatientId { get; set; }

        [ForeignKey(nameof(PatientId))]
        [InverseProperty("External_Medical_Reports")]
        public virtual Patient Patient { get; set; }
    }
}
