using HK_Clinic2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HK_Clinic2.Services
{
    public class StudentService
    {
        // Instance of the db context
        private readonly HKClinicDbContext db;

        // Constructor using dependency injection
        public StudentService(HKClinicDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get patients of type student
        /// </summary>
        /// <returns>List of all students</returns>
        public List<Patient> GetStudents()
        {
            return db.Patient.Where(c => c.Type == 1).ToList();
        }

        /// <summary>
        /// Get a student
        /// </summary>
        /// <param name="id">Id of the student to return</param>
        /// <returns>A student with the provided id or null</returns>
        public Patient GetStudent(int id)
        {
            return db.Patient.Where(c => c.Type == 1).SingleOrDefault(c => c.PatientId == id);
        }

        /// <summary>
        /// Add a new student
        /// </summary>
        /// <param name="student">The student to add</param>
        /// <returns>True if student is added successfuly otherwise false</returns>
        public bool AddStudent(Student student)
        {
            if (student != null)
            {
                db.Student.Add(student);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Update a student
        /// </summary>
        /// <param name="student">student object</param>

        public void UpdateStudent(Student student)
        {
            // Change the state of the student object to modified, so it will be update in database
            db.Entry(student).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
