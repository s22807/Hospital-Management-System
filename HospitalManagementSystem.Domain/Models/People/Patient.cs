using HospitalManagementSystem.Domain.Models.Department;
using HospitalManagementSystem.Domain.Models.Payments;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Domain.Models.People
{
    public class Patient : Person, IUser
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public virtual IEnumerable<Visit> Visits { get; set; } = Enumerable.Empty<Visit>();
        public virtual IEnumerable<Payment> Payments { get; set; } = Enumerable.Empty<Payment>();
        public DateTime? DeletedAt { get; private set; }
        public DateTime? LoggedAt { get; private set; }
        public string? Email;
        public string? Username;
        public string? Password;
        public void Login()
        {
            this.LoggedAt = DateTime.Now;
        }
        public void Delete()
        {
            this.DeletedAt = DateTime.Now;
        }

        //IF PATIENT IS A CHILD
        public string? MothersName { get; private set; }
        public string? FathersName { get; private set; }


        public bool Insured { get; private set; }

        public string Role => "Patient";

        public void AddVisit(Visit visit)
        {
            if (visit != null && visit.Patient != this)
            {
                try
                {
                    visit.SetPatient(this);
                    if (!Visits.Contains(visit))   
                    {
                        Visits.Append(visit);
                    }
                }
                catch
                {
                    throw new ArgumentException("Visit already has a patient.");
                }
                
            }
        }

        public void SetMothersName(string name)
        {
            //if name is null and birthdate is less than 18 years ago
            if (name == null && BirthDate.Date.AddYears(18) > DateTime.Today)
            {
                throw new ArgumentException("Mothers name cannot be null.");
            }
            MothersName = name;

        }
        public void SetFathersName(string name)
        {
            if (name == null && BirthDate.Date.AddYears(18) > DateTime.Today)
            {
                throw new ArgumentException("Fathers name cannot be null.");
            }
            FathersName = name;
        }

        //public virtual User user { get; set; } = null;
        public Patient(string firstName, string lastName, string pesel, DateTime birthDate, bool sex, bool insured, string? MothersName, string? FathersName)
        : base(firstName, lastName, pesel, birthDate, sex)
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            SetMothersName(MothersName);
            SetFathersName(FathersName);
            Insured = insured;
        }
        
        
        
    }
}

