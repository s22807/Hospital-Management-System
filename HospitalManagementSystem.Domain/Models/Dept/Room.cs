using HospitalManagementSystem.Domain.Models.People;

namespace HospitalManagementSystem.Domain.Models.Department
{
    public class Room
    {
        public Guid Id { get; }
        public int Number { get; set; }
        public Guid? DepartmentId { get; private set; }
        public virtual Department? Department { get; set; }
        public virtual IEnumerable<Visit> Visits { get; set; } = Enumerable.Empty<Visit>();
        public virtual IEnumerable<Key> Keys { get; set; } = new List<Key>();
        private void SetRoomNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Room number cannot be negative");
            }
            
            Number = number;
        }

        public Room(int number, Department d)
        {
            Id = Guid.NewGuid();
            try
            {
                Department = d;
                d.Rooms.Add(this);
                SetRoomNumber(number);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public Room(int number)
        {
            Id = Guid.NewGuid();
            try
            {
                SetRoomNumber(number);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public class Key
        {
            public Guid Id { get; }
            public Guid RoomId { get; set; }
            public Guid? DoctorId { get; set; }
            public DateTime? RentedDate { get; set; }
            public DateTime? ReturnedDate { get; set; }
            public virtual Employee? Employee { get; set; }
            public virtual Room Room { get; set; }

            private Key(Guid roomId)
            {
                RoomId = roomId;
                Id = Guid.NewGuid();
            }
            
            public void RentKey(Employee employee)
            {
                if (employee != null)
                {
                    if (employee.Role == Employee.EmpKind.Doctor)
                    {
                        if (employee.Department == Room.Department)
                        {
                            if (employee.RentedKeys.Count() >= 3)
                            {
                                if (RentedDate == null || Employee == null)
                                {
                                    RentedDate = DateTime.Now;
                                    ReturnedDate = null;
                                    Employee = employee;
                                    DoctorId = employee.Id;
                                    employee.RentedKeys.Append(this);
                                }
                                else
                                {
                                    throw new ArgumentException("Key is already rented.");
                                }
                            }
                            else
                            {
                                throw new ArgumentException("Limit 3 keys per Employee.");
                            }
                        }
                        else
                        {
                            throw new ArgumentException("Employee is not in the same department as the room.");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Employee must be a doctor.");
                    }
                }
                else
                {
                    throw new ArgumentException("Employee cannot be null.");
                }
            }
            public void ReturnKey()
            {
                if (Employee != null || RentedDate != null)
                {
                    if (Employee.RentedKeys.Contains(this))
                    {

                        ReturnedDate = DateTime.Now;
                        RentedDate = null;
                        Employee.RentedKeys.Remove(this);
                        Employee = null;
                    }
                    else
                    {
                        throw new ArgumentException("Employee does not have this key.");
                    }
                }
                else
                {
                    throw new ArgumentException("Key is already returned.");
                }
            }
        }
    }
}
