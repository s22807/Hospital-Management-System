using HospitalManagementSystem.Domain.Models.People;

namespace HospitalManagementSystem.Application.Models
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Sex { get; set; }
        public DateTime FireDate { get; set; }
        public int Salary { get; set; }
        public int VacationDays { get; set; }
        public string EmpKind { get; set; }
        public int? VisitTime { get; set; }
        public int? HoursWorked { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? TagId { get; set; }

        public EmployeeDTO(Employee employee)
        {
            this.Id = employee.Id;
            this.FirstName = employee.FirstName;
            this.LastName = employee.LastName;
            this.Pesel = employee.Pesel;
            this.Birthdate = employee.BirthDate;
            this.Sex = employee.Sex;
            this.FireDate = employee.FireDate;
            this.Salary = employee.Salary;
            this.VacationDays = employee.VacationDays;
            this.EmpKind = employee.Role.ToString();
            this.VisitTime = employee.VisitTime;
            this.HoursWorked = employee.HoursWorked;
            this.TagId = employee.TagId;
        }
        public EmployeeDTO() { }
        
    }
}