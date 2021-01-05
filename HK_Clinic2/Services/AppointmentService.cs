using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HK_Clinic2.Models;
using Microsoft.EntityFrameworkCore;

namespace HK_Clinic2.Services
{
    public class AppointmentService
    {
        // Instance of the db context
        private readonly HKClinicDbContext db;

        // Constructor using dependency injection
        public AppointmentService(HKClinicDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all Appointments
        /// </summary>
        /// <returns>List of all Appointments</returns>
        public List<Appointment> GetAppointments()
        {
            return db.Appointment.ToList();
        }

        public List<Appointment> GetConfirmedAppointments()
        {
            return db.Appointment.Where(x => x.Status == 1).ToList();
        }
        public List<Appointment> GetPendingAppointments()
        {
            return db.Appointment.Where(x => x.Status == 2).ToList();
        }

        /// <summary>
        /// Get an Appointment
        /// </summary>
        /// <param name="id">Id of the Appointment to return</param>
        /// <returns>An Appointment with the provided id or null</returns>
        public Appointment GetAppointment(int id)
        {
            return db.Appointment.SingleOrDefault(c => c.AppointmentId == id);
        }

        /// <summary>
        /// Add a new Appointment
        /// </summary>
        /// <param name="appointment">The Appointment to add</param>
        /// <returns>True if Appointment is added successfuly otherwise false</returns>
        public bool AddAppointment(Appointment appointment)
        {
            if (appointment != null)
            {
                db.Appointment.Add(appointment);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Edit an Appointment
        /// </summary>
        /// <param name="appointment">appointment object</param>
        public void UpdateAppointment(Appointment appointment)
        {
            // Change the state of the Appointment object to modified, so it will be updated in database
            db.Entry(appointment).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool ConfirmAppointment(int id)
        {
            var appointment = db.Appointment.Find(id);
            if (appointment != null)
            {
                appointment.Status = 1;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool CancelAppointment(int id)
        {
            var appointment = db.Appointment.Find(id);
            if (appointment != null)
            {
                appointment.Status = 3;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool PendingAppointment(int id)
        {
            var appointment = db.Appointment.Find(id);
            if (appointment != null)
            {
                appointment.Status = 2;
                db.SaveChanges();
                return true;
            }
            return false;
        }

    }
}