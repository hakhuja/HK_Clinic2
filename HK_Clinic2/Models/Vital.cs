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
        public int? Weight { get; set; }
        public int? Height { get; set; }
        public int? HeartRate { get; set; }
        public int? RespiratoryRate { get; set; }
        public int? Temperature { get; set; }
        public int? BloodSugar { get; set; }
        [StringLength(50)]
        public string BloodPressure { get; set; }
        public int VisitId { get; set; }

        [ForeignKey(nameof(VisitId))]
        [InverseProperty("Vitals")]
        public virtual Visit Visit { get; set; }
    }
}
