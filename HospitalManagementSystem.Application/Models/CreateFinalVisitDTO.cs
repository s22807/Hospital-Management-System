using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.Models
{
    public class CreateFinalVisitDTO
    {
        //public CreateFinalVisitDTO(VisitSlotDTO? visitSlot, PatientDTO patientDTO)
        //{
        //    PatientId = patientDTO.Id;
        //    RoomId = visitSlot.RoomId;
        //    TagId = visitSlot.TagId;
        //    visitDate = visitSlot.VisitStartDate;
        //    DoctorId = visitSlot.DoctorId;
        //}
        public CreateFinalVisitDTO() { }

        public DateTime VisitStartDate { get; set; }
        public DateTime VisitEndDate { get; set; }
        public Guid DoctorId { get; set; }
        public Guid RoomId { get; set; }
        public Guid TagId { get; set; }
        public int RoomNumber { get; set; }
        public string TagName { get; set; }
        public Guid PatientId { get; set; }
    }
}
