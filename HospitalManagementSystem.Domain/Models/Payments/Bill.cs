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
        public virtual Patient Patient { get; set; }
        public double Amount { get; set; }
        public double PaidAmount { get; set; }
        public bool IsPaid { get; set; }

        public Bill(Guid visitId, Guid patientId, double amount, bool isPaid)
        {
            BillId = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            VisitId = visitId;
            PatientId = patientId;
            Amount = amount;
            IsPaid = isPaid;
        }
        
        public virtual Visit Visit { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }


    }
}
