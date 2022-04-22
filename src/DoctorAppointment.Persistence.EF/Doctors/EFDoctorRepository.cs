using DoctorAppointment.Entities;
using DoctorAppointment.Services.Doctors.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Persistence.EF.Doctors
{
    public class EFDoctorRepository : DoctorRepository
    {
        private readonly DbSet<Doctor> _doctors;

        public EFDoctorRepository(ApplicationDbContext dbcontext)
        {
            _doctors = dbcontext.Set<Doctor>();
        }

        public void Add(Doctor doctor)
        {
            _doctors.Add(doctor);
        }

        public void Delete(Doctor doctor)
        {
            _doctors.Remove(doctor);
        }

        public Doctor Find(int id)
        {
            return _doctors.Find(id);
        }

        public List<GetAllDoctorsDto> GetAllDoctors()
        {
            return _doctors.Select(x => new GetAllDoctorsDto
            {
                Field = x.Field,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Id = x.Id,
                NationalCode = x.NationalCode,
                Appointments = x.Appointments
            }).ToList();
        }

        public bool IsExistNationalCode(string nationalCode)
        {
            return _doctors.Any(_ => _.NationalCode == nationalCode);
        }

        public void Update(Doctor doctor)
        {
            _doctors.Update(doctor);
        }
    }
}
