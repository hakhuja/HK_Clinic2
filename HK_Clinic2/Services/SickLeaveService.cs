using HK_Clinic2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HK_Clinic2.Services
{
    public class SickLeaveService
    {
        // Instance of the db context
        private readonly HKClinicDbContext db;

        // Constructor using dependency injection
        public SickLeaveService(HKClinicDbContext context)
        {
            db = context;
        }

        public List<Sick_Leave> GetSickLeaves()
        {
            return db.Sick_Leave.ToList();
        }
    }
}
