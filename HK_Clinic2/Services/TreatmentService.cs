using HK_Clinic2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HK_Clinic2.Services
{
    public class TreatmentService
    {
        // Instance of the db context
        private readonly HKClinicDbContext db;

        // Constructor using dependency injection
        public TreatmentService(HKClinicDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all treatments
        /// </summary>
        /// <returns>List of all treatments</returns>
        public List<Treatment> GetTreatments()
        {
            return db.Treatment.ToList();
        }

        /// <summary>
        /// Get a treatment
        /// </summary>
        /// <param name="id">Id of the treatment to return</param>
        /// <returns>A treatment with the provided id or null</returns>
        public Treatment GetTreatment(int id)
        {
            return db.Treatment.SingleOrDefault(c => c.TreatmentId == id);
        }

        /// <summary>
        /// Add a new treatment
        /// </summary>
        /// <param name="treatment">The treatment to add</param>
        /// <returns>True if treatment is added successfuly otherwise false</returns>
        public bool AddTreatment(Treatment treatment)
        {
            if (treatment != null)
            {
                db.Treatment.Add(treatment);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Update a treatment
        /// </summary>
        /// <param name="treatment">treatment object</param>

        public void UpdateTreatment(Treatment treatment)
        {
            // Change the state of the treatment object to modified, so it will be update in database
            db.Entry(treatment).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
