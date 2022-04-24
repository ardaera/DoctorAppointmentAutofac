using DoctorAppointment.Entities;
using DoctorAppointment.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Appointments.Contracts
{
    public interface AppointmentService: Service
    {
        void Add(AddAppointmentDto dto);
        List<GetAllAppointmentsDto> GetAllAppointments();
        Appointment Find(int id);
        void Delete(Appointment appointment);
        void Update(Appointment appointment, UpdateAppointmentDto dto);
    }
}
