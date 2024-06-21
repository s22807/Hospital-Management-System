using HospitalManagementSystem.Domain.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.Models
{
    public class DepartmentEmployeeDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmpKind { get; set; }
        public DepartmentEmployeeDTO(Employee employee)
        {
            this.Id = employee.Id;
            this.FirstName = employee.FirstName;
            this.LastName = employee.LastName;
            this.EmpKind = employee.Role.ToString();
        }
    }
}
