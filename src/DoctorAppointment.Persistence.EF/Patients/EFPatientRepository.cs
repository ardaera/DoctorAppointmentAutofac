using DoctorAppointment.Entities;
using DoctorAppointment.Services.Patients.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Persistence.EF.Patients
{
    public class EFPatientRepository : PatientRepository
    {
        private readonly DbSet<Patient> _patients;

        public EFPatientRepository(ApplicationDbContext dbcontext)
        {
            _patients = dbcontext.Set<Patient>();
        }

        public void Add(Patient patient)
        {
            _patients.Add(patient);
        }

        public void Delete(Patient patient)
        {
            _patients.Remove(patient);
        }

        public Patient Find(int id)
        {
            return _patients.Find(id);
        }

        public List<GetAllPatientsDto> GetAllPatients()
        {
            return _patients.Select(x => new GetAllPatientsDto
            {
                FirstName = x.FirstName,
                Id = x.Id,
                LastName = x.LastName,
                NationalCode = x.NationalCode
            }).ToList();
        }

        public bool IsExistNationalCode(string nationalCode)
        {
            return _patients.Any(_ => _.NationalCode == nationalCode);
        }

        public void Update(Patient patient)
        {
            _patients.Update(patient);
        }
    }
}
