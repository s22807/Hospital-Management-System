using HospitalManagementSystem.Domain.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.Models
{
    public class DepartmentDetailsDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<EmployeeDTO> Employees { get; set; } = new List<EmployeeDTO>();
        public List<RoomDTO> Rooms { get; set; } = new List<RoomDTO>();
        public DepartmentDetailsDTO(Department d)
        {
            this.Id = d.Id;
            this.Name = d.Name;
            this.Employees = d.Employees.Select(e => new EmployeeDTO(e)).ToList();
            this.Rooms = d.Rooms.Select(r => new RoomDTO(r)).ToList();
        }
    }
}
