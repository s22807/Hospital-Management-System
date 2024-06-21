using HospitalManagementSystem.Domain.Models.People;

namespace HospitalManagementSystem.Domain.Models.Payments
{
    public class Payment
    {
        public Guid PaymentId { get; }
        public DateTime CreatedAt { get; }
        public Guid PatientId { get; }
        public Guid BillId { get; }
        public double Amount { get; }
        
        public Payment(Patient patient, Bill bill, double amount) {
            PaymentId = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            PatientId = patient.Id;
            BillId = bill.BillId;
            Amount = amount;
        }
        private Payment(double amount)
        {
            PaymentId = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            Amount = amount;
        }


        public virtual Bill Bill { get; }
        public virtual Patient Patient { get; }
        
    }
}
