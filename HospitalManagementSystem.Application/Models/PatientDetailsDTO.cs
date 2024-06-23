using HospitalManagementSystem.Domain.Models.People;
using HospitalManagementSystem.Domain.Models.Department;

namespace HospitalManagementSystem.Application.Models
{
    public class PatientDetailsDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Sex { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? MothersName { get; set; }
        public string? FathersName { get; set; }
        public string SelectedTag { get; set; }
        public bool Insured { get; set; }

        public PatientDetailsDTO(Patient patient, IEnumerable<Visit> visits)
        {
            Id = patient.Id;
            FirstName = patient.FirstName;
            LastName = patient.LastName;
            Pesel = patient.Pesel;
            Birthdate = patient.BirthDate;
            Sex = patient.Sex;
            CreatedAt = patient.CreatedAt;
            Visits = visits.Select(v => new VisitDTO(v)).ToList();
            DeletedAt = patient.DeletedAt;
            LoggedAt = patient.LoggedAt;
            MothersName = patient.MothersName;
            FathersName = patient.FathersName;
            Insured = patient.Insured;
        }

        
        public IEnumerable<VisitDTO> Visits { get; set; } = Enumerable.Empty<VisitDTO>();
        public DateTime? DeletedAt { get; set; }
        public DateTime? LoggedAt { get; set; }
        

    }
}
