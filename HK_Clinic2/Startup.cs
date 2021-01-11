using HK_Clinic2.Data;
using HK_Clinic2.Models;
using HK_Clinic2.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;
using NotificationService = Radzen.NotificationService;

namespace HK_Clinic2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();

            services.AddScoped<DialogService>();
            services.AddScoped<NotificationService>();

            // Add DbContext to services
            services.AddDbContext<HKClinicDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Add services to retrieve data from the database
            services.AddScoped<AddressService>();
            services.AddScoped<AllergyService>();
            services.AddScoped<AppointmentService>();
            services.AddScoped<ClinicService>();
            services.AddScoped<EquipmentService>();
            services.AddScoped<EventService>();
            services.AddScoped<ExternalMedicalReportService>();
            services.AddScoped<FamilyDoctorService>();
            services.AddScoped<InventoryService>();
            services.AddScoped<MedicalIncidentService>();
            services.AddScoped<NurseService>();
            services.AddScoped<ParentService>();
            services.AddScoped<PatientService>();
            services.AddScoped<SickLeaveService>();
            services.AddScoped<TeacherService>();
            services.AddScoped<TreatmentService>();
            services.AddScoped<VisitService>();
            services.AddScoped<VitalsService>();
            services.AddSingleton<GlobalUsernameService>();
            services.AddScoped<GlobalUsernameService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
