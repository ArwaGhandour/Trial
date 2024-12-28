using Clinic_Final.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Final.Models
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
       public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> patients {  get; set; }
        public DbSet<Appointment> appointments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasOne(d=>d.doctors)
                .WithMany(a=>a.Appointments)
                .HasForeignKey(x=>x.Doctoridd)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Appointment>()
                .HasOne(p=>p.patients)
                .WithMany(a => a.Appointments)
                .HasForeignKey(x => x.Patientidd)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
