using DoctorAppointment.Entities;
using DoctorAppointment.Infrastructure.Application;
using DoctorAppointment.Services.Appointments.Contracts;
using DoctorAppointment.Services.Doctors.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Appointments
{
    public class AppointmentAppService : AppointmentService
    {
        private readonly AppointmentRepository _repository;
        private readonly DoctorRepository _doctorRepository;
        private readonly UnitOfWork _unitOfWork;

        public AppointmentAppService(
            AppointmentRepository repository, DoctorRepository doctorRepository,
            UnitOfWork unitOfWork)
        {
            _repository = repository;
            _doctorRepository = doctorRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddAppointmentDto dto)
        {
            Appointment appointment = new Appointment
            {
                PatientId = dto.PatientId,
                Date = dto.Date,
                DoctorId = dto.DoctorId
            };
            var doctor = _doctorRepository.GetAllDoctors().FirstOrDefault(x =>
             x.Id == dto.DoctorId);
            if (doctor.Appointments.Count < 5)
            {
                _repository.Add(appointment);
                _unitOfWork.Commit();
            }
            else
            {
                throw new AppointmentIsFullException();
            }
        }

        public void Delete(Appointment appointment)
        {
            if (_repository.Find(appointment.Id) != appointment)
            {
                throw new AppointmentNotFoundException();
            }
            else
            {
                _repository.Delete(appointment);
                _unitOfWork.Commit();
            }
        }

        public Appointment Find(int id)
        {
            return _repository.Find(id);
        }

        public List<GetAllAppointmentsDto> GetAllAppointments()
        {
            return _repository.GetAllAppointments();
        }

        public void Update(Appointment appointment, UpdateAppointmentDto dto)
        {
            if (_repository.Find(appointment.Id) != appointment)
            {
                throw new AppointmentNotFoundException();
            }
            else
            {
                appointment.DoctorId = dto.DoctorId;
                appointment.PatientId = dto.PatientId;
                appointment.Date = dto.Date;
                _repository.Update(appointment);
                _unitOfWork.Commit();
            }
        }
    }
}
