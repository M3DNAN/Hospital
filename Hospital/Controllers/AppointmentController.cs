using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Hospital.Controllers
{
    public class AppointmentController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MyAppointments()
        {
            var Appointment = context.Appointments.ToList();
            return View(Appointment);
        }
        public IActionResult ViewMyAppointments(Appointment appointment)
        {
            appointment.DoctorName = (string)TempData["CurrentDoctorName"];
            appointment.DoctorId = (int)TempData["CurrentDoctorID"];

            context.Appointments.Add(appointment);
            context.SaveChanges();
            return RedirectToAction("MyAppointments");
        }
    }
}
