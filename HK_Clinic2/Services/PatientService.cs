using HK_Clinic2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HK_Clinic2.Services
{
    public class PatientService
    {
        // Instance of the db context
        private readonly HKClinicDbContext db;

        // Constructor using dependency injection
        public PatientService(HKClinicDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all patients
        /// </summary>
        /// <returns>List of all patients</returns>
        public List<Patient> GetPatients()
        {
            //return db.Patient.Include("Student").Include("Employee").ToList();
            return db.Patient.Include("Address").Include("Student").ToList();
        }

        /// <summary>
        /// Get a patient
        /// </summary>
        /// <param name="id">Id of the patient to return</param>
        /// <returns>A patient with the provided id or null</returns>
        public Patient GetPatient(int id)
        {
            return db.Patient.SingleOrDefault(c => c.PatientId == id);
        }

        /// <summary>
        /// Add a new patient
        /// </summary>
        /// <param name="patient">The patient to add</param>
        /// <returns>True if patient is added successfuly otherwise false</returns>
        public bool AddPatient(Patient patient)
        {
            if (patient != null)
            {
                db.Patient.Add(patient);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// How to Archive a patient?
        /// </summary>

        /// <summary>
        /// Update a patient
        /// </summary>
        /// <param name="patient">patient object</param>
        public void UpdatePatient(Patient patient)
        {
            // Change the state of the patient object to modified, so it will be update in database
            db.Entry(patient).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
