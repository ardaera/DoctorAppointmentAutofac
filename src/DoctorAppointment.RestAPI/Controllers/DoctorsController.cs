using DoctorAppointment.Entities;
using DoctorAppointment.Services.Doctors;
using DoctorAppointment.Services.Doctors.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DoctorAppointment.RestAPI.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly DoctorService _service;

        public DoctorsController(DoctorService service)
        {
            _service = service;
        }

        [HttpPost]
        public void AddDoctor(AddDoctorDto dto)
        {
            _service.Add(dto);
        }

        [HttpGet]
        public List<GetAllDoctorsDto> GetAllDoctors()
        {
            return _service.GetAllDoctors();
        }

        [HttpDelete("{id}")]
        public void DeleteDoctor(int id)
        {
            var doctor = _service.Find(id);
            _service.Delete(doctor);
        }

        [HttpPut("{id}")]
        public void UpdateDoctor(int id, UpdateDoctorDto dto)
        {
            var doctor = _service.Find(id);
            _service.Update(doctor,dto);
        }
    }
}
