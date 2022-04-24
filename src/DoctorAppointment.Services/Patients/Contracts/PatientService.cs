using DoctorAppointment.Entities;
using DoctorAppointment.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Patients.Contracts
{
    public interface PatientService: Service
    {
        void Add(AddPatientDto dto);
        List<GetAllPatientsDto> GetAllPatients();
        Patient Find(int id);
        void Delete(Patient patient);
        void Update(Patient patient, UpdatePatientDto dto);
    }
}
