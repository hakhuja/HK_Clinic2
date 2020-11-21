using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("Medicine")]
    public partial class Medicine
    {
        [Key]
        public int InventoryId { get; set; }
        [Required]
        public string Dosage { get; set; }
        public string Barcode { get; set; }
        public int Type { get; set; }

        [ForeignKey(nameof(InventoryId))]
        [InverseProperty("Medicine")]
        public virtual Inventory Inventory { get; set; }
    }
}
