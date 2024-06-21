using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.Models
{
    public class EmployeeCreateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Sex { get; set; }
        public int Salary { get; set; }
        public Guid DepartmentId { get; set; }
        public string EmpKind { get; set; }
    }
}
