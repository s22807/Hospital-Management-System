using HospitalManagementSystem.Domain.Models.People;

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

        public PatientDetailsDTO(Patient patient)
        {
            Id = patient.Id;
            FirstName = patient.FirstName;
            LastName = patient.LastName;
            Pesel = patient.Pesel;
            Birthdate = patient.BirthDate;
            Sex = patient.Sex;
            CreatedAt = patient.CreatedAt;
            Visits = patient.Visits.Select(v => new VisitDTO(v)).ToList();
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
