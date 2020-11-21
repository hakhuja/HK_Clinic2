using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HK_Clinic2.Models
{
    public class PType
    {
        public PType(int id, string name)
        {
            TypeId = id; TypeName = name;
        }
        [Key]
        public int TypeId { get; set; }

        public string TypeName { get; set; }
    }
}
