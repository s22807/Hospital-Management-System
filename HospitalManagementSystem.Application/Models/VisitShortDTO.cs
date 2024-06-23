using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.Models
{
    public class VisitShortDTO
    {
        public Guid Id { get; set; }
        public DateTime? VisitStartDate { get; set; }
        public DateTime? VisitEndDate { get; set; }
        public Guid? DoctorId { get; set; }
        public int? RoomNumber { get; set; }
        public Guid? PatientId { get; set; }
        public string? TagName { get; set; }
        public bool IsCancelled { get; set; }
        public string Status { get; set; }
    }
}
