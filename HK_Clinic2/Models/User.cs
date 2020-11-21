using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("User")]
    public partial class User
    {
        public User()
        {
            Nurses = new HashSet<Nurse>();
            Teachers = new HashSet<Teacher>();
        }

        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(30)]
        public string Username { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        public int Type { get; set; }

        [InverseProperty(nameof(Nurse.User))]
        public virtual ICollection<Nurse> Nurses { get; set; }
        [InverseProperty(nameof(Teacher.User))]
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
