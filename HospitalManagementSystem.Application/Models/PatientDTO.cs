using HospitalManagementSystem.Domain.Models.People;

namespace HospitalManagementSystem.Application.Models
{
    public class PatientDTO
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
        public bool Insured { get; set; } 

        public PatientDTO(Patient patient)
        {
            Id = patient.Id;
            FirstName = patient.FirstName;
            LastName = patient.LastName;
            Pesel = patient.Pesel;
            Birthdate = patient.BirthDate;
            Sex = patient.Sex;
            CreatedAt = patient.CreatedAt;
            MothersName = patient.MothersName;
            FathersName = patient.FathersName;
            Insured = patient.Insured;
        }
        public PatientDTO()
        {
            
        }
    }
}
