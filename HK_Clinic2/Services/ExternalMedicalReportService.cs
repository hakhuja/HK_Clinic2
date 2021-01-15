using HK_Clinic2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HK_Clinic2.Services
{
    public class ExternalMedicalReportService
    {
        // Instance of the db context
        private readonly HKClinicDbContext db;

        // Constructor using dependency injection
        public ExternalMedicalReportService(HKClinicDbContext context)
        {
            db = context;
        }

        public List<External_Medical_Report> GetMedicalReports()
        {
            return db.External_Medical_Reports.ToList();
        }
    }
}
