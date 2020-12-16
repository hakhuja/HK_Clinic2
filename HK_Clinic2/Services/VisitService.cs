using HK_Clinic2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HK_Clinic2.Services
{
    public class VisitService
    {

        // Instance of the db context
        private readonly HKClinicDbContext db;

        // Constructor using dependency injection
        public VisitService(HKClinicDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all visits
        /// </summary>
        /// <returns>List of all visits</returns>
        public List<Visit> GetVisits()
        {
            // Include patient and appointment entities to be loaded with Visit
            return db.Visit.Include("Patient").Include("Treatment").ToList();
        }

        /// <summary>
        /// Get a Visit
        /// </summary>
        /// <param name="id">Id of the visit to return</param>
        /// <returns>A visit with the provided id or null</returns>
        public Visit GetVisit(int id)
        {
            return db.Visit.SingleOrDefault(c => c.VisitId == id);
        }

        /// <summary>
        /// Add a new visit
        /// </summary>
        /// <param name="visit">The visit to add</param>
        /// <returns>True if visit is added successfuly otherwise false</returns>
        public bool AddVisit(Visit visit)
        {
            if (visit != null)
            {
                db.Visit.Add(visit);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Update a visit
        /// </summary>
        /// <param name="visit">visit object</param>

        public void UpdateVisit(Visit visit)
        {
            // Change the state of the visit object to modified, so it will be update in database
            db.Entry(visit).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
