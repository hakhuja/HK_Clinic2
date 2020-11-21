using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Keyless]
    public partial class Visit_Treatment
    {
        public int VisitId { get; set; }
        public DateTime VisitDateTime { get; set; }
        [Required]
        public string Assessment { get; set; }
        public int Status { get; set; }
        public int TreatmentId { get; set; }
        public string Description { get; set; }
    }
}
