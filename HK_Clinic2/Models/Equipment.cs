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
        [StringLength(20)]
        [Range(0, 9999999999999999999, ErrorMessage = "The range for the Building Number is 0 - 999999")]
        public string SerialNumber { get; set; }
        [StringLength(50)]
        public string Manufacturer { get; set; }

        [ForeignKey(nameof(InventoryId))]
        [InverseProperty("Equipment")]
        public virtual Inventory Inventory { get; set; }
    }
}
