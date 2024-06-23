using HospitalManagementSystem.Application.Models;
using HospitalManagementSystem.Application.Repositories;
using HospitalManagementSystem.Domain.Models.Department;
using HospitalManagementSystem.Domain.Models.Payments;
using HospitalManagementSystem.Domain.Models.People;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;

namespace HospitalManagementSystem.Application.Services
{
    public interface IVisitService
    {
        Task<Guid> CreateVisit(VisitSlotDTO createFinalVisitDTO);
        Task<IEnumerable<VisitShortDTO>> GetCurrentVisitsAsync();
        Task<IEnumerable<VisitSlotDTO>> GetVisitSlots(TagDTO tagDTO, Guid patientId);
    }

    internal class VisitService : IVisitService
    {
        private readonly IVisitRepository _visitRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IPaymentsRepository _paymentsRepository;
        private readonly double visitCost;
        public VisitService(IVisitRepository visitRepository, IEmployeeRepository employeeRepository, 
            IPatientRepository patientRepository, IDepartmentRepository departmentRepository, 
            ITagRepository tagRepository, IPaymentsRepository paymentsRepository,
            IConfiguration configuration)
        {
            _visitRepository = visitRepository;
            _employeeRepository = employeeRepository;
            _patientRepository = patientRepository;
            _departmentRepository = departmentRepository;
            _tagRepository = tagRepository;
            _paymentsRepository = paymentsRepository;
            visitCost = configuration.GetValue<double>("VisitCost");
        }

        public async Task<Guid> CreateVisit(VisitSlotDTO createFinalVisitDTO)
        {
            var visit = new Visit(createFinalVisitDTO.PatientId,createFinalVisitDTO.DoctorId, createFinalVisitDTO.RoomId,createFinalVisitDTO.VisitStartDate,createFinalVisitDTO.TagId);
            await _paymentsRepository.CreateBill(visit.Bill);
            await _visitRepository.CreateVisitAsync(visit);
            return visit.Id;
        }

        public async Task<IEnumerable<VisitShortDTO>> GetCurrentVisitsAsync()
        {
            var visits = await _visitRepository.GetVisitSince(DateTime.Now);
            
            List<VisitShortDTO> visitShorts = new List<VisitShortDTO>();

            foreach (var visit in visits)
            {
                visitShorts.Add(new VisitShortDTO {
                    VisitStartDate = visit.VisitStartDate,
                    //VisitEndDate = visit.VisitStartDate.AddMinutes((double)visit.Doctor.VisitTime),
                    DoctorId = visit.DoctorId,
                    RoomNumber = visit.Room.Number,
                    PatientId = visit.PatientId,
                    TagName = visit.Tag.Name,
                    IsCancelled = visit.IsCancelled,
                    Id = visit.Id
                });

    }
            return visitShorts;
        }
        
        public async Task<IEnumerable<VisitSlotDTO>> GetVisitSlots(TagDTO tagDTO, Guid patientId)
        {
            if (tagDTO.Id == null) throw new Exception("No tagId provided");
            var tag = await _tagRepository.GetTagAsync((Guid)tagDTO.Id);
            var slots = await _visitRepository.GetFreeSlots(tag);
            List<VisitSlotDTO> slotsDTO = new List<VisitSlotDTO>();
            foreach (var slot in slots)
            {
                slotsDTO.Add(new VisitSlotDTO
                {
                    VisitStartDate = slot.slotStartTime,
                    VisitEndDate = slot.slotEndTime,
                    DoctorId=slot.Doctor.Id,
                    RoomId = slot.Room.Id,
                    TagId = slot.Tag.Id,
                    RoomNumber=slot.Room.Number,
                    TagName=slot.Tag.Name,
                    PatientId=patientId
                });
            }
            return slotsDTO;
        }



        //public async Task CreateVisitAsync(CreateDraftVisitDTO createVisitDTO)
        //{

        //    Patient patient = await _patientRepository.GetAsync(createVisitDTO.PatientId);
        //    Employee? doctor = await _employeeRepository.GetAsync(createVisitDTO.DoctorId);
        //    Room? room = await _departmentRepository.GetRoomAsync(createVisitDTO.RoomId);
        //    Bill bill = Bill.Create(patient, visitCost);

        //    var visit = Visit.Create(patient, doctor, room, bill, createVisitDTO.VisitDate);

        //    await _visitRepository.CreateVisitAsync(visit);
        //}

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
