using DoctorAppointment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Doctors.Contracts
{
    public interface DoctorRepository
    {
        void Add(Doctor doctor);
        bool IsExistNationalCode(string nationalCode);
        List<GetAllDoctorsDto> GetAllDoctors();
        void Delete(Doctor doctor);
        Doctor Find(int id);
        void Update(Doctor doctor);
    }
}
