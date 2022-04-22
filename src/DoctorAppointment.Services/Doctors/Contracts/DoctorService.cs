using DoctorAppointment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Doctors.Contracts
{
    public interface DoctorService
    {
        void Add(AddDoctorDto dto);
        List<GetAllDoctorsDto> GetAllDoctors();
        Doctor Find(int id);
        void Delete(Doctor doctor);
        void Update(Doctor doctor, UpdateDoctorDto dto);
    }
}
