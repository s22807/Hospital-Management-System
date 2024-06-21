using HospitalManagementSystem.Domain.Models.People;

namespace HospitalManagementSystem.Application.Repositories
{
    public interface IPatientRepository
    {
        Task AddAsync(Patient patient);
        Task Delete(Guid patientId);
        Task<Patient?> GetPatientAsync(Guid patientId);
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task<IEnumerable<Patient>> GetPatientsAsync(string? firstname, string? lastname, string? pesel);
        Task Remove(Guid id);
        Task Update(Patient patient);
    }
}

