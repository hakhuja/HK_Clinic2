using HK_Clinic2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HK_Clinic2.Services
{
    public class FamilyDoctorService
    {
        // Instance of the db context
        private readonly HKClinicDbContext db;

        // Constructor using dependency injection
        public FamilyDoctorService(HKClinicDbContext context)
        {
            db = context;
        }

        public List<FamilyDoctor> GetFamilyDoctors()
        {
            return db.FamilyDoctor.ToList();
        }

        public FamilyDoctor GetFamilyDoctor(int id)
        {
            return db.FamilyDoctor.SingleOrDefault(c => c.DoctorId == id);
        }

        public bool AddFamilyDoctor(FamilyDoctor familyDoctor)
        {
            if (familyDoctor != null)
            {
                db.FamilyDoctor.Add(familyDoctor);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteFamilyDoctor(int id)
        {
            var familyDoctor = db.FamilyDoctor.Find(id);
            if (familyDoctor != null)
            {
                db.FamilyDoctor.Remove(familyDoctor);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public void UpdateFamilyDoctor(FamilyDoctor familyDoctor)
        {
            db.Entry(familyDoctor).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
