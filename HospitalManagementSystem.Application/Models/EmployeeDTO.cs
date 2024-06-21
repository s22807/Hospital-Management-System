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
        }
        
    }
}