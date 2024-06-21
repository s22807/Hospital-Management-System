namespace HospitalManagementSystem.Application.Models
{
    public record CreateVisitDTO(Guid patientId, Guid BillId, DateTime VisitDate, Guid? DoctorId, Guid? RoomId);
}