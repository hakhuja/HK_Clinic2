using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HK_Clinic2.Models
{
    public partial class HKClinicDbContext : DbContext
    {
        public HKClinicDbContext()
        {
        }

        public HKClinicDbContext(DbContextOptions<HKClinicDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Allergy> Allergy { get; set; }
        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Class_Teacher> Class_Teacher { get; set; }
        public virtual DbSet<Clinic> Clinic { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Event_Nurse> Event_Nurse { get; set; }
        public virtual DbSet<External_Medical_Report> External_Medical_Reports { get; set; }
        public virtual DbSet<FamilyDoctor> FamilyDoctor { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Inventory_Equipment> Inventory_Equipment { get; set; }
        public virtual DbSet<Inventory_Medicine> Inventory_Medicine { get; set; }
        public virtual DbSet<Medical_Incident> Medical_Incidents { get; set; }
        public virtual DbSet<Medical_Incident_Patient> Medical_Incident_Patient { get; set; }
        public virtual DbSet<Medicine> Medicine { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Notification_Nurse> Notification_Nurse { get; set; }
        public virtual DbSet<Notification_Parent> Notification_Parent { get; set; }
        public virtual DbSet<Nurse> Nurse { get; set; }
        public virtual DbSet<Parent> Parent { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Patient_Allergy> Patient_Allergy { get; set; }
        public virtual DbSet<Prescription> Prescription { get; set; }
        public virtual DbSet<Sick_Leave> Sick_Leave { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Student_Appointment> Student_Appointment { get; set; }
        public virtual DbSet<Student_Info> Student_Info { get; set; }
        public virtual DbSet<Student_Parent> Student_Parent { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<Treatment> Treatment { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Visit> Visit { get; set; }
        public virtual DbSet<Visit_Treatment> Visit_Treatment { get; set; }
        public virtual DbSet<Vital> Vital { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-OALN5637;Initial Catalog=HK_Clinic1;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.City).HasDefaultValueSql("('Jeddah')");

                entity.Property(e => e.Country).HasDefaultValueSql("('Saudi Arabia')");
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasOne(d => d.Nurse)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.NurseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointment_Nurse");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointment_Teacher");
            });

            modelBuilder.Entity<Class_Teacher>(entity =>
            {
                entity.HasOne(d => d.Class)
                    .WithMany()
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Class_Tea__Class__44CA3770");

                entity.HasOne(d => d.Employee)
                    .WithMany()
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Class_Tea__Emplo__45BE5BA9");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.InventoryId).ValueGeneratedNever();

                entity.HasOne(d => d.Inventory)
                    .WithOne(p => p.Equipment)
                    .HasForeignKey<Equipment>(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Equipment_Inventory");
            });

            modelBuilder.Entity<Event_Nurse>(entity =>
            {
                entity.HasKey(e => new { e.EventId, e.EmployeeId });

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Event_Nurses)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_Nurse_Nurse");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Event_Nurses)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_Nurse_Event");
            });

            modelBuilder.Entity<External_Medical_Report>(entity =>
            {
                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.External_Medical_Reports)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_External_Medical_Report_Patient");
            });

            modelBuilder.Entity<FamilyDoctor>(entity =>
            {
                entity.HasOne(d => d.Student)
                    .WithMany(p => p.FamilyDoctors)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FamilyDoctor_Student");
            });

            modelBuilder.Entity<Inventory_Equipment>(entity =>
            {
                entity.ToView("Inventory_Equipment");
            });

            modelBuilder.Entity<Inventory_Medicine>(entity =>
            {
                entity.ToView("Inventory_Medicine");
            });

            modelBuilder.Entity<Medical_Incident_Patient>(entity =>
            {
                entity.HasKey(e => new { e.PatientId, e.MedicalIncidentId });

                entity.HasOne(d => d.MedicalIncident)
                    .WithMany(p => p.Medical_Incident_Patients)
                    .HasForeignKey(d => d.MedicalIncidentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medical_Incident_Patient_Medical_Incident");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Medical_Incident_Patients)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medical_Incident_Patient_Patient");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.Property(e => e.InventoryId).ValueGeneratedNever();

                entity.HasOne(d => d.Inventory)
                    .WithOne(p => p.Medicine)
                    .HasForeignKey<Medicine>(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medicine_Inventory");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK_Notification_Appointment");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK_Notification_Inventory");
            });

            modelBuilder.Entity<Notification_Nurse>(entity =>
            {
                entity.HasKey(e => new { e.NotificationId, e.EmployeeId });

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Notification_Nurses)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notification_Nurse_Nurse");

                entity.HasOne(d => d.Notification)
                    .WithMany(p => p.Notification_Nurses)
                    .HasForeignKey(d => d.NotificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notification_Nurse_Notification");
            });

            modelBuilder.Entity<Notification_Parent>(entity =>
            {
                entity.HasKey(e => new { e.NotificationId, e.ParentId });

                entity.HasOne(d => d.Notification)
                    .WithMany(p => p.Notification_Parents)
                    .HasForeignKey(d => d.NotificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notification_Parent_Notification");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Notification_Parents)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notification_Parent_Parent");
            });

            modelBuilder.Entity<Nurse>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK_Nurse_1");

                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.Nurses)
                    .HasForeignKey(d => d.ClinicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Nurse_Clinic");

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.Nurse)
                    .HasForeignKey<Nurse>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Nurse_Employee");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Nurses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Nurse_User");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patient_Address");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Patient_Employee");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Patient_Student");
            });

            modelBuilder.Entity<Patient_Allergy>(entity =>
            {
                entity.HasKey(e => new { e.PatientId, e.AllergyId });

                entity.HasOne(d => d.Allergy)
                    .WithMany(p => p.Patient_Allergies)
                    .HasForeignKey(d => d.AllergyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patient_Allergy_Allergy");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Patient_Allergies)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patient_Allergy_Patient");
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prescription_Inventory");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prescription_Patient");

                entity.HasOne(d => d.Treatment)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.TreatmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prescription_Treatment");
            });

            modelBuilder.Entity<Sick_Leave>(entity =>
            {
                entity.HasOne(d => d.Visit)
                    .WithMany(p => p.Sick_Leaves)
                    .HasForeignKey(d => d.VisitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sick_Leave_Visit");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId).ValueGeneratedNever();

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__Student__ClassId__489AC854");
            });

            modelBuilder.Entity<Student_Info>(entity =>
            {
                entity.ToView("Student_Info");
            });

            modelBuilder.Entity<Student_Parent>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.ParentId });

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Student_Parents)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_Student_Parent_Address");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Student_Parents)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Parent_Parent");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Student_Parents)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Parent_Student");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.Teacher)
                    .HasForeignKey<Teacher>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Teacher_Employee");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Teacher_User");
            });

            modelBuilder.Entity<Visit>(entity =>
            {
                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.AppointmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Visit_Appointment");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK_Visit_Inventory");

                entity.HasOne(d => d.Notification)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.NotificationId)
                    .HasConstraintName("FK_Visit_Notification");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Visit_Patient");

                entity.HasOne(d => d.Treatment)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.TreatmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Visit_Treatment");
            });

            modelBuilder.Entity<Visit_Treatment>(entity =>
            {
                entity.ToView("Visit_Treatment");
            });

            modelBuilder.Entity<Vital>(entity =>
            {
                entity.Property(e => e.Temperature).HasDefaultValueSql("((37))");

                entity.HasOne(d => d.Visit)
                    .WithMany(p => p.Vitals)
                    .HasForeignKey(d => d.VisitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vitals_Visit");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.Staff)
                    .HasForeignKey<Staff>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Staff_Employee");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
