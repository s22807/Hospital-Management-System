using HospitalManagementSystem.Application.Models;
using HospitalManagementSystem.Application.Repositories;
using HospitalManagementSystem.Domain.Models.Department;
using HospitalManagementSystem.Domain.Models.Payments;
using HospitalManagementSystem.Domain.Models.People;
using Microsoft.Extensions.Configuration;

namespace HospitalManagementSystem.Application.Services
{
    public interface IVisitService
    {
        Task CreateVisitAsync(CreateVisitDTO createVisitDTO);
    }

    internal class VisitService : IVisitService
    {
        private readonly IVisitRepository _visitRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly double visitCost;
        public VisitService(IVisitRepository visitRepository, IEmployeeRepository employeeRepository, IPatientRepository patientRepository, IDepartmentRepository departmentRepository, IConfiguration configuration)
        {
            _visitRepository = visitRepository;
            _employeeRepository = employeeRepository;
            _patientRepository = patientRepository;
            _departmentRepository = departmentRepository;
            visitCost = configuration.GetValue<double>("VisitCost");
        }

        public async Task CreateVisitAsync(CreateVisitDTO createVisitDTO)
        {
            Patient patient = await _patientRepository.GetAsync(createVisitDTO.patientId);
            Employee? doctor = await _employeeRepository.GetAsync(createVisitDTO.DoctorId);
            Room? room = await _departmentRepository.GetRoomAsync(createVisitDTO.RoomId);
            Bill bill = Bill.Create(patient, visitCost);

            var visit = Visit.Create(patient, doctor, room, bill, createVisitDTO.VisitDate);

            await _visitRepository.CreateVisitAsync(visit);
        }

        //public async Task UpdateVisitAsync(Guid id, VisitDTO visitDTO)
        //{
        //    var visit = await _visitRepository.GetAsync(id);

        //    visit.SetVisitDate(visitDTO.VisitDate);

        //    if (visitDTO.DoctorDto)
        //    {
        //        var doctor = await _employeeRepository.GetAsync(doctorId);
        //        visit.SetDoctor(doctor);
        //    }

        //    await _visitRepository.UpdateAsync(visit);
        //}
    }
}
