using DoctorAppointment.Services.Appointments.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DoctorAppointment.RestAPI.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentService _service;

        public AppointmentsController(AppointmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public void AddPatient(AddAppointmentDto dto)
        {
            _service.Add(dto);
        }

        [HttpGet]
        public List<GetAllAppointmentsDto> GetAllAppointments()
        {
            return _service.GetAllAppointments();
        }

        [HttpDelete("{id}")]
        public void DeleteAppointment(int id)
        {
            var appointment = _service.Find(id);
            _service.Delete(appointment);
        }

        [HttpPut("{id}")]
        public void UpdateAppointment(int id, UpdateAppointmentDto dto)
        {
            var appointment = _service.Find(id);
            _service.Update(appointment, dto);
        }
    }
}
