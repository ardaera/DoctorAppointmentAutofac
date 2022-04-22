using DoctorAppointment.Services.Patients.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DoctorAppointment.RestAPI.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly PatientService _service;

        public PatientsController(PatientService service)
        {
            _service = service;
        }

        [HttpPost]
        public void AddPatient(AddPatientDto dto)
        {
            _service.Add(dto);
        }

        [HttpGet]
        public List<GetAllPatientsDto> GetAllPatients()
        {
            return _service.GetAllPatients();
        }

        [HttpDelete("{id}")]
        public void DeletePatient(int id)
        {
            var patient = _service.Find(id);
            _service.Delete(patient);
        }

        [HttpPut("{id}")]
        public void UpdatePatient(int id, UpdatePatientDto dto)
        {
            var patient = _service.Find(id);
            _service.Update(patient, dto);
        }
    }
}
