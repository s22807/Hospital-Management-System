using HospitalManagementSystem.Domain.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.Models
{
    public class VisitDTO
    {
        public VisitDTO(Visit v)
        {
        }

        public int Id { get; set; }
        public string DeptName { get; set; }
        public DateTime VisitStartDate { get; set; }
        public DateTime VisitEndDate { get; set; }
        public int RoomNumber { get; set; }
        public Guid PatientId { get; set; }
    }
}
