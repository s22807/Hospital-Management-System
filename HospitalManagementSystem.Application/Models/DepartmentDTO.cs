using HospitalManagementSystem.Domain.Models.Department;

namespace HospitalManagementSystem.Application.Models
{
    public class DepartmentDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DepartmentDTO(Department d)
        {
            this.Id = d.Id;
            this.Name = d.Name;
        }
    }
}
