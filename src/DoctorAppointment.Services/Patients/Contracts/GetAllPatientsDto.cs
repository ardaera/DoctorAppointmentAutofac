﻿namespace DoctorAppointment.Services.Patients.Contracts
{
    public class GetAllPatientsDto
    {
        public int Id { get; set; }
        public string NationalCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}