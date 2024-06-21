namespace HospitalManagementSystem.Application.Models
{
    public class VisitSlotDTO
    {
        public DateTime VisitStartDate { get; set; }
        public DateTime VisitEndDate { get; set; }
        public Guid DoctorId { get; set; }
        public Guid RoomId { get; set; }
        public Guid TagId { get; set; }
        public int RoomNumber { get; set; }
        public string TagName { get; set; }
        public Guid PatientId { get; set; }
    }

}