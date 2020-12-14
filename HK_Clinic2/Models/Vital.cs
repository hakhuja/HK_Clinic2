using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    public partial class Vital
    {
        [Key]
        public int VitalsId { get; set; }
        [Range(0,250, ErrorMessage ="The range for the Weight is 0 - 250")]
        public int? Weight { get; set; }
        [Range(0, 250, ErrorMessage = "The range for the Height is 0 - 250")]
        public int? Height { get; set; }
        [Range(0, 150, ErrorMessage = "The range for the Heart Rate is 0 - 150")]
        public int? HeartRate { get; set; }
        [Range(0, 250, ErrorMessage = "The range for the Respiratory Rate is 0 - 250")]
        public int? RespiratoryRate { get; set; }
        [Range(34, 42, ErrorMessage = "The range for the Temperature is 34 - 42")]
        public int? Temperature { get; set; }
        [Range(0, 250, ErrorMessage = "The range for the Blood Sugar is 0 - 250")]
        public int? BloodSugar { get; set; }
        [StringLength(50)]
        [Range(0, 250, ErrorMessage = "The range for the Blood Pressure is 0 - 250")]
        public string BloodPressure { get; set; }
        public int VisitId { get; set; }

        [ForeignKey(nameof(VisitId))]
        [InverseProperty("Vitals")]
        public virtual Visit Visit { get; set; }
    }
}
