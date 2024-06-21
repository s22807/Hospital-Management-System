using HospitalManagementSystem.Domain.Models.Payments;
using HospitalManagementSystem.Domain.Models.People;


namespace HospitalManagementSystem.Domain.Models.Department
{

    public class Visit
    {
        public Guid Id { get; private set; }
        public DateTime VisitDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public Guid? DoctorId { get; private set; }
        public Guid PatientId { get; private set; }
        public Guid? RoomId { get; private set; }
        public Guid BillId { get; private set; }
        
        public virtual Employee? Doctor { get; private set; }
        public virtual Patient Patient { get; private set; }
        public virtual Room? Room { get; private set; }
        public virtual Bill Bill { get; private set; }
        public static double VisitCost { get; private set; } = 1000;

        private Visit(Guid patientId, Guid? doctorId, Guid? roomId, Guid billId, DateTime visitDate)
        {
            Id = Guid.NewGuid();
            SetVisitDate(visitDate);
            CreatedAt = DateTime.Now;
            UpdatedAt = null;
            PatientId = patientId;
            DoctorId = doctorId;
            RoomId = roomId;
            BillId = billId;
        }
        private Visit(Patient patient, Employee? doctor, Room? room, Bill bill, DateTime visitDate)
        {
            Id = Guid.NewGuid();
            SetVisitDate(visitDate);
            CreatedAt = DateTime.Now;
            UpdatedAt = null;
            SetPatient(patient);
            SetDoctor(doctor);
            SetRoom(room);
            SetBill(bill);
        }

        public static Visit Create(Patient patient, Employee? doctor, Room? room, Bill bill, DateTime visitDate)
            => new(patient, doctor, room, bill, visitDate);

        public static void SetVisitCost(double cost)
        {
            if (cost < 0)
            {
                throw new ArgumentException("Visit cost cannot be negative.");
            }
            VisitCost = cost;
        }
        private void SetVisitDate(DateTime value)
        {
            if (value == null)
            {
                throw new ArgumentException("Visit date cannot be null.");
            }


            if (value < DateTime.Now)
            {
                throw new ArgumentException("Visit date cannot be in the past.");
            }
            VisitDate = value;

        }
        private void Update()
        {
            UpdatedAt = DateTime.Now;
        }
        public void SetDoctor(Employee? value)
        {
            if (value != null && value.Role == Employee.EmpKind.Doctor)
            {
                Doctor = value;
            }
            else
            {
                throw new ArgumentException("Employee must be a doctor.");
            }
        }
        public void SetPatient(Patient value)
        {
            if (value != null)
            {
                Patient = value;
            }
            else
            {
                throw new ArgumentException("Patient cannot be null.");
            }
        }
        private void SetRoom(Room value)
        {
            if (value != null)
            {
                Room = value;
            }
            else
            {
                throw new ArgumentException("Room must exist.");
            }
        }
        private void SetBill(Bill value)
        {
            if (value != null)
            {
                Bill = value;
            }
            else
            {
                throw new ArgumentException("Bill must exist.");
            }
        }




    }
}
