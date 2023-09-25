using HealthcareManagementApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthcareManagementApplication.Data
{
    public class HealthcareManagementDbContext:DbContext
    {
        public HealthcareManagementDbContext(DbContextOptions<HealthcareManagementDbContext>options):base(options)
        {
            
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Facility> Facilities { get; set; }

        public DbSet<Medication> Medications { get; set; }

    }
}
