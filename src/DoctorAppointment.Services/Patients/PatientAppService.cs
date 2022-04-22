using DoctorAppointment.Entities;
using DoctorAppointment.Infrastructure.Application;
using DoctorAppointment.Services.Patients.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Patients
{
    public class PatientAppService:PatientService
    {
        private readonly PatientRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public PatientAppService(
            PatientRepository repository,
            UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddPatientDto dto)
        {
            var patient = new Patient
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                NationalCode = dto.NationalCode,
            };

            var isPatientExist = _repository
                .IsExistNationalCode(patient.NationalCode);

            if (isPatientExist)
            {
                throw new PatientAlreadyExistException();
            }

            _repository.Add(patient);
            _unitOfWork.Commit();
        }

        public void Delete(Patient patient)
        {
            if (_repository.Find(patient.Id) != patient)
            {
                throw new PatientNotFoundException();
            }
            else
            {
                _repository.Delete(patient);
                _unitOfWork.Commit();
            }
        }

        public Patient Find(int id)
        {
            return _repository.Find(id);
        }

        public List<GetAllPatientsDto> GetAllPatients()
        {
            return _repository.GetAllPatients();
        }

        public void Update(Patient patient, UpdatePatientDto dto)
        {
            if (_repository.Find(patient.Id) != patient)
            {
                throw new PatientNotFoundException();
            }
            else
            {
                patient.FirstName = dto.FirstName;
                patient.LastName = dto.LastName;
                patient.NationalCode = dto.NationalCode;

                var isDoctorExist = _repository
                .IsExistNationalCode(patient.NationalCode);
                if (isDoctorExist)
                {
                    throw new PatientAlreadyExistException();
                }

                _repository.Update(patient);
                _unitOfWork.Commit();
            }
        }
    }
}
