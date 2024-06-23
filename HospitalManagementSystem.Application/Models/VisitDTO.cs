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
            Id = v.Id;
            VisitStartDate = v.VisitStartDate;
            RoomNumber = v.Room.Number;
            PatientId = v.PatientId;
        }

        public Guid Id { get; set; }
        public DateTime VisitStartDate { get; set; }
        public int RoomNumber { get; set; }
        public Guid PatientId { get; set; }
    }
}
