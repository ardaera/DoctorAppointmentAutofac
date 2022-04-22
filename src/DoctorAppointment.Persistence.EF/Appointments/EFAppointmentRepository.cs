using DoctorAppointment.Entities;
using DoctorAppointment.Services.Appointments.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Persistence.EF.Appointments
{
    public class EFAppointmentRepository : AppointmentRepository
    {
        private readonly DbSet<Appointment> _appointments;

        public EFAppointmentRepository(ApplicationDbContext dbcontext)
        {
            _appointments = dbcontext.Set<Appointment>();
        }

        public void Add(Appointment appointment)
        {
            _appointments.Add(appointment);
        }

        public void Delete(Appointment appointment)
        {
            _appointments.Remove(appointment);
        }

        public Appointment Find(int id)
        {
            return _appointments.Find(id);
        }

        public List<GetAllAppointmentsDto> GetAllAppointments()
        {
            return _appointments.Select(x => new GetAllAppointmentsDto
            {
                Date = x.Date,
                DoctorId = x.DoctorId,
                PatientId = x.PatientId
            }).ToList();
        }

        public void Update(Appointment appointment)
        {
            _appointments.Update(appointment);
        }
    }
}
