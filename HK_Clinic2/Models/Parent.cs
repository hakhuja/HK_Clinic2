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
        [Required(ErrorMessage = "The First Name field is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The Last Name field is required.")]
        public string LastName { get; set; }
        [Required]
        [StringLength(10)]
        [Range(00000000000, 9999999999, ErrorMessage = "The Mobile field must contain 10 digits")]
        [RegularExpression("(05)(5|0|3|6|4|9|1|8|7)([0-9]{7})", ErrorMessage = "Wrong mobile number format. Ex. 05XXXXXXXX ")]
        public string Mobile { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int Guardian { get; set; }
        public int Relationship { get; set; }

        [InverseProperty(nameof(Notification_Parent.Parent))]
        public virtual ICollection<Notification_Parent> Notification_Parents { get; set; }
        [InverseProperty(nameof(Student_Parent.Parent))]
        public virtual ICollection<Student_Parent> Student_Parents { get; set; }
    }
}
