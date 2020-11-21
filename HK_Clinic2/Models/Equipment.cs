using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    public partial class Equipment
    {
        [Key]
        public int InventoryId { get; set; }
        [StringLength(50)]
        public string SerialNumber { get; set; }
        [StringLength(50)]
        public string Manufacturer { get; set; }

        [ForeignKey(nameof(InventoryId))]
        [InverseProperty("Equipment")]
        public virtual Inventory Inventory { get; set; }
    }
}
