using HospitalManagementSystem.Domain.Models.Department;
using HospitalManagementSystem.Domain.Models.People;

namespace HospitalManagementSystem.Domain.Models.Payments
{
    public class Bill
    {
        public Guid BillId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid VisitId { get; set; }
        public Guid PatientId { get; set; }
        public double Cost { get; set; }
        
        public Bill(Guid visitId, Guid patientId, double cost)
        {
            BillId = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            VisitId = visitId;
            PatientId = patientId;
            Cost = cost; 
        }
        
        public virtual Visit Visit { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }

        public static Bill Create(Patient patient, double visitCost)
        {
            throw new NotImplementedException();
        }
    }
}
