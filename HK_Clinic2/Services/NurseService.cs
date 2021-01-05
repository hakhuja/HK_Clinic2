using HK_Clinic2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HK_Clinic2.Services
{
    public class NurseService
    {
        // Instance of the db context
        private readonly HKClinicDbContext db;

        // Constructor using dependency injection
        public NurseService(HKClinicDbContext context)
        {
            db = context;
        }

        public List<Nurse> GetNurses()
        {
            return db.Nurse.ToList();
        }
    }
}
