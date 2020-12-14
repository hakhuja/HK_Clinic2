using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("Event")]
    public partial class Event
    {
        public Event()
        {
            Event_Nurses = new HashSet<Event_Nurse>();
        }

        [Key]
        public int EventId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        [Range(0, 99, ErrorMessage = "The range for the Capacity is 0 - 99")]
        public int? Capacity { get; set; }
        public int? Type { get; set; }

        [InverseProperty(nameof(Event_Nurse.Event))]
        public virtual ICollection<Event_Nurse> Event_Nurses { get; set; }
    }
}
