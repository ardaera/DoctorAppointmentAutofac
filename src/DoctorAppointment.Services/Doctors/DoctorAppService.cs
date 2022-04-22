using DoctorAppointment.Entities;
using DoctorAppointment.Infrastructure.Application;
using DoctorAppointment.Services.Doctors.Contracts;
using DoctorAppointment.Services.Doctors.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Doctors
{
    public class DoctorAppService : DoctorService
    {
        private readonly DoctorRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public DoctorAppService(
            DoctorRepository repository,
            UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddDoctorDto dto)
        {
            var doctor = new Doctor
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Field = dto.Field,
                NationalCode = dto.NationalCode
            };

            var isDoctorExist = _repository
                .IsExistNationalCode(doctor.NationalCode);

            if (isDoctorExist)
            {
                throw new DoctorAlreadyExistException();
            }

            _repository.Add(doctor);
            _unitOfWork.Commit();
        }

        public void Delete(Doctor doctor)
        {
            if (_repository.Find(doctor.Id) != doctor)
            {
                throw new DoctorNotFoundException();
            }
            else
            {
                _repository.Delete(doctor);
                _unitOfWork.Commit();
            }
        }

        public Doctor Find(int id)
        {
            return _repository.Find(id);
        }

        public List<GetAllDoctorsDto> GetAllDoctors()
        {
            return _repository.GetAllDoctors();
        }

        public void Update(Doctor doctor, UpdateDoctorDto dto)
        {
            if (_repository.Find(doctor.Id) != doctor)
            {
                throw new DoctorNotFoundException();
            }
            else
            {
                doctor.FirstName = dto.FirstName;
                doctor.LastName = dto.LastName;
                doctor.NationalCode = dto.NationalCode;
                doctor.Field = dto.Field;

                var isDoctorExist = _repository
                .IsExistNationalCode(doctor.NationalCode);
                if (isDoctorExist)
                {
                    throw new DoctorAlreadyExistException();
                }

                _repository.Update(doctor);
                _unitOfWork.Commit();
            }
        }
    }
}
