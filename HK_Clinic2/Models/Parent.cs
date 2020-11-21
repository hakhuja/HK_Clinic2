using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HK_Clinic2.Models
{
    [Table("Parent")]
    public partial class Parent
    {
        public Parent()
        {
            Notification_Parents = new HashSet<Notification_Parent>();
            Student_Parents = new HashSet<Student_Parent>();
        }

        [Key]
        public int ParentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [StringLength(10)]
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int Guardian { get; set; }
        public int Relationship { get; set; }

        [InverseProperty(nameof(Notification_Parent.Parent))]
        public virtual ICollection<Notification_Parent> Notification_Parents { get; set; }
        [InverseProperty(nameof(Student_Parent.Parent))]
        public virtual ICollection<Student_Parent> Student_Parents { get; set; }
    }
}
