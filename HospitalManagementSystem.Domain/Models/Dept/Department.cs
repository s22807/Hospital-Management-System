using HospitalManagementSystem.Domain.Models.People;

namespace HospitalManagementSystem.Domain.Models.Department
{
    public class Department
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } = null!; 
        public virtual ICollection<Room> Rooms { get; set; } = null!;
        
        public Department(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }
        private void SetName(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name cannot be null or empty");
            }
            Name = name;
        }

        public void AddEmployee(Employee employee)
        {
            if (!Employees.Contains(employee))
                Employees.Add(employee);
            employee.SetDepartment(this);
        }

        public void RemoveEmployee(Employee employee)
        {
            if (Employees.Contains(employee))
                Employees.Remove(employee);
            employee.SetDepartment(null);
        }
        public void AddRoom(Room room)
        {
            if (!Rooms.Contains(room))
                Rooms.Add(room);
            room.Department = this;
        }
        public void RemoveRoom(Room room)
        {
            if (Rooms.Contains(room))
                Rooms.Remove(room);
            room.Department = null;
        }
        
    }
}
