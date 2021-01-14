using HK_Clinic2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HK_Clinic2.Services
{
    public class EmployeeService
    {
        // Instance of the db context
        private readonly HKClinicDbContext db;

        // Constructor using dependency injection
        public EmployeeService(HKClinicDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get patients of type employee
        /// </summary>
        /// <returns>List of all employees</returns>
        public List<Patient> GetEmployees()
        {
            return db.Patient.Where(c => c.Type == 2).ToList();
        }

        /// <summary>
        /// Get an employee
        /// </summary>
        /// <param name="id">Id of the employee to return</param>
        /// <returns>An employee with the provided id or null</returns>
        public Patient GetEmployee(int id)
        {
            return db.Patient.Where(c => c.Type == 2).SingleOrDefault(c => c.PatientId == id);
        }

        /// <summary>
        /// Add a new employee
        /// </summary>
        /// <param name="employee">The employee to add</param>
        /// <returns>True if employee is added successfuly otherwise false</returns>
        public bool AddEmployee(Employee employee)
        {
            if (employee != null)
            {
                db.Employee.Add(employee);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Update an employee
        /// </summary>
        /// <param name="employee">employee object</param>

        public void UpdateEmployee(Employee employee)
        {
            // Change the state of the employee object to modified, so it will be update in database
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
