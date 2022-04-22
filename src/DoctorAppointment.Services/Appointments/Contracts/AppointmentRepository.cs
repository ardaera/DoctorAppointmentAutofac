using DoctorAppointment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Appointments.Contracts
{
    public interface AppointmentRepository
    {
        void Add(Appointment appointment);
        List<GetAllAppointmentsDto> GetAllAppointments();
        void Delete(Appointment appointment);
        Appointment Find(int id);
        void Update(Appointment appointment);
    }
}
