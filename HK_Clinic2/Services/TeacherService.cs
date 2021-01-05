using HK_Clinic2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HK_Clinic2.Services
{
    public class TeacherService
    {
        // Instance of the db context
        private readonly HKClinicDbContext db;

        // Constructor using dependency injection
        public TeacherService(HKClinicDbContext context)
        {
            db = context;
        }

        public List<Teacher> GetTeachers()
        {
            return db.Teacher.ToList();
        }
    }
}
