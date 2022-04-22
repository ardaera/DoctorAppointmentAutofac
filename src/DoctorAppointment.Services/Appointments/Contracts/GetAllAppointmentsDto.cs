using System;

namespace DoctorAppointment.Services.Appointments.Contracts
{
    public class GetAllAppointmentsDto
    {
        public DateTime Date { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }
}