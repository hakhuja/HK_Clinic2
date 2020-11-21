using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("Sick_Leave")]
    public partial class Sick_Leave
    {
        [Key]
        public int SickLeaveId { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        public int VisitId { get; set; }

        [ForeignKey(nameof(VisitId))]
        [InverseProperty("Sick_Leaves")]
        public virtual Visit Visit { get; set; }
    }
}
