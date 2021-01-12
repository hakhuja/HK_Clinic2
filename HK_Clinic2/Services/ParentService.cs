using HK_Clinic2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HK_Clinic2.Services
{
    public class ParentService
    {
        // Instance of the db context
        private readonly HKClinicDbContext db;

        // Constructor using dependency injection
        public ParentService(HKClinicDbContext context)
        {
            db = context;
        }

        public List<Parent> GetParents()
        {
            return db.Parent.ToList();
        }

        public Parent GetParent(int id)
        {
            return db.Parent.SingleOrDefault(c => c.ParentId == id);
        }

        public bool AddParent(Parent parent)
        {
            if (parent != null)
            {
                db.Parent.Add(parent);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteParent(int id)
        {
            var parent = db.Parent.Find(id);
            if (parent != null)
            {
                db.Parent.Remove(parent);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public void UpdateParent(Parent parent)
        {
            db.Entry(parent).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
