using HospitalManagementSystem.Domain.Models.Department;

namespace HospitalManagementSystem.Application.Repositories
{
    public interface IVisitRepository
    {
        Task CreateVisitAsync(Visit visit);
        Task<Visit> GetAsync(Guid id);
        Task<IEnumerable<VisitSlot>> GetFreeSlots(Tag tag);
        Task<IEnumerable<Visit>> GetVisitSince(DateTime now);
        Task UpdateAsync(Visit visit);
    }
}
