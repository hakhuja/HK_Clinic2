using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Keyless]
    public partial class Inventory_Medicine
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0, 999999, ErrorMessage = "The range for the Quantity In Stock is 0 - 999999")]
        public int QuantityInStock { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        [Column(TypeName = "date")]
        public DateTime ExpiryDate { get; set; }
        [Range(0, 99, ErrorMessage = "The range for the Limit is 0 - 99")]
        public int Limit { get; set; }
        [Required]
        public string Dosage { get; set; }
        public string Barcode { get; set; }
        public int Type { get; set; }
    }
}
