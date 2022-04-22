using DoctorAppointment.Entities;
using System.Collections.Generic;

namespace DoctorAppointment.Services.Doctors.Contracts
{
    public class GetAllDoctorsDto
    {
        public GetAllDoctorsDto()
        {
            Appointments = new List<Appointment>();
        }
        public int Id { get; set; }
        public string NationalCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Field { get; set; }
        public List<Appointment> Appointments { get; set; }

    }
}