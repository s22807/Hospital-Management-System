using HospitalManagementSystem.Domain.Models.Department;

namespace HospitalManagementSystem.Application.Models
{
    public class VisitDTO
    {
        public Guid Id { get; set; }
        public DateTime VisitDate { get; set; }
        

        public VisitDTO(Visit v)
        {
            
        }
    }
}
