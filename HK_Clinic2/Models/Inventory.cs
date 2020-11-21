using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("Inventory")]
    public partial class Inventory
    {
        public Inventory()
        {
            Notifications = new HashSet<Notification>();
            Prescriptions = new HashSet<Prescription>();
            Visits = new HashSet<Visit>();
        }

        [Key]
        public int InventoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int QuantityInStock { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        [Column(TypeName = "date")]
        public DateTime ExpiryDate { get; set; }
        public int Limit { get; set; }
        public int Type { get; set; }

        [InverseProperty("Inventory")]
        public virtual Equipment Equipment { get; set; }
        [InverseProperty("Inventory")]
        public virtual Medicine Medicine { get; set; }
        [InverseProperty(nameof(Notification.Inventory))]
        public virtual ICollection<Notification> Notifications { get; set; }
        [InverseProperty(nameof(Prescription.Inventory))]
        public virtual ICollection<Prescription> Prescriptions { get; set; }
        [InverseProperty(nameof(Visit.Inventory))]
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
