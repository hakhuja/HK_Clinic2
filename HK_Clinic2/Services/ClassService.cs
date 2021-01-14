using HK_Clinic2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HK_Clinic2.Services
{
    public class ClassService
    {
        // Instance of the db context
        private readonly HKClinicDbContext db;

        // Constructor using dependency injection
        public ClassService(HKClinicDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get classes
        /// </summary>
        /// <returns>List of all classes</returns>
        public List<Class> GetClasses()
        {
            return db.Class.ToList();
        }

        /// <summary>
        /// Get a class
        /// </summary>
        /// <param name="id">Id of the class to return</param>
        /// <returns>A class with the provided id or null</returns>
        public Class GetClass(int id)
        {
            return db.Class.SingleOrDefault(c => c.ClassId == id);
        }

        /// <summary>
        /// Add a new class
        /// </summary>
        /// <param name="class">The class to add</param>
        /// <returns>True if class is added successfuly otherwise false</returns>
        public bool AddClass(Class studentClass)
        {
            if (studentClass != null)
            {
                db.Class.Add(studentClass);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Update a class
        /// </summary>
        /// <param name="class">class object</param>

        public void UpdateClass(Class studentClass)
        {
            // Change the state of the employee object to modified, so it will be update in database
            db.Entry(studentClass).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
