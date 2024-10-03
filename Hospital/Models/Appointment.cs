namespace Hospital.Models
{
           public class Appointment
    {
        public int Id { get; set; }

             public string Name { get; set; }
            public DateTime Date { get; set; }
            public TimeSpan Time { get; set; }
            public int DoctorId { get; set; }
            public Doctor Doctor { get; set; }

        }
    }


