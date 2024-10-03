using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Hospital.Controllers
{
    public class DoctorsController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public IActionResult Index()
        {
        return View(); 
        }
        public IActionResult CompleteAppointment(string name)
        {
           
            var Appointment = context.Doctors.Where(e=>e.Name==name).FirstOrDefault();
            TempData["CurrentDoctorName"] = Appointment.Name;
            TempData["CurrentDoctorID"] = Appointment.Id;

            return View(Appointment);
        }
        public IActionResult BookAppointment()
        {
            var Doctor = context.Doctors.ToList();
            return View(Doctor);
           
        }

    }
}
