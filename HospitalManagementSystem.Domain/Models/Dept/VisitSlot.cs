using HospitalManagementSystem.Domain.Models.Department;
using HospitalManagementSystem.Domain.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Domain.Models.Department
{
    public class VisitSlot
    {
        public Employee Doctor { get; set; }
        public Room Room { get; set; }
        public DateTime slotStartTime { get; set; }
        public DateTime slotEndTime { get; set; }
        public Tag Tag { get; set; }
        public VisitSlot(Employee doctor, Room room, DateTime slotStartTime, DateTime slotEndTime, Tag tag)
        {
            Doctor = doctor;
            Room = room;
            this.slotStartTime = slotStartTime;
            this.slotEndTime = slotEndTime;
            Tag = tag;
        }
    }
}
