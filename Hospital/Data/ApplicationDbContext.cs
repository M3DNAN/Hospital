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
    }

}
