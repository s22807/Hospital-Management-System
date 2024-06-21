using HospitalManagementSystem.Domain.Models.Department;

namespace HospitalManagementSystem.Application.Repositories
{
    public interface IVisitRepository
    {
        Task CreateVisitAsync(Visit visit);
        Task<Visit> GetAsync(Guid id);
        Task UpdateAsync(Visit visit);
    }
}
