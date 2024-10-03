using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var Builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
            var connection = Builder.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connection);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                   new Doctor { Id = 1, Name = "Dr. John Smith", Specialization = "Cardiology", Img = "doctor1.jpg" },
                   new Doctor { Id = 2, Name = "Dr. Sarah Johnson", Specialization = "Pediatrics", Img = "doctor3.jpg" },
                   new Doctor { Id = 3, Name = "Dr. Emily Davis", Specialization = "Dermatology", Img = "doctor5.jpg" },
                   new Doctor { Id = 4, Name = "Dr. Michael Lee", Specialization = "Orthopedics", Img = "doctor6.jpg" },
                   new Doctor { Id = 5, Name = "Dr. William Clark", Specialization = "Neurology", Img = "doctor4.jpg" }
               );

            modelBuilder.HasSequence<int>("IdNumbers");

            modelBuilder.Entity<Appointment>()
                .Property(o => o.Id)
                .HasDefaultValueSql("NEXT VALUE FOR IdNumbers");
        }
    }

}
