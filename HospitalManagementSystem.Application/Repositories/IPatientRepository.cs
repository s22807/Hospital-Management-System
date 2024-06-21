using HospitalManagementSystem.Domain.Models.People;

namespace HospitalManagementSystem.Application.Repositories
{
    public interface IPatientRepository
    {
        Task AddAsync(Patient patient);
        Task Delete(Guid patientId);
        Task<Patient?> GetAsync(Guid patientId);
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task Remove(Guid id);
    }
}

