using DoctorAppointment.Entities;
using DoctorAppointment.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Patients.Contracts
{
    public interface PatientRepository: Repository
    {
        void Add(Patient patient);
        bool IsExistNationalCode(string nationalCode);
        List<GetAllPatientsDto> GetAllPatients();
        void Delete(Patient patient);
        Patient Find(int id);
        void Update(Patient patient);
    }
}
