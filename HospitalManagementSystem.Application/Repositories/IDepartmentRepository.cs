using HospitalManagementSystem.Domain.Models.Department;

namespace HospitalManagementSystem.Application.Repositories
{
    public interface IDepartmentRepository
    {
        Task CreateDepartmentAsync(Department department);
        Task<IEnumerable<Department>> GetDepartmentsAsync();
        Task<Department> GetDepartmentDetailsAsync(Guid id);
        Task<Room?> GetRoomAsync(Guid? roomId);
        Task CreateRoomAsync(Room room);
        Task<Department> GetDepartmentAsync(Guid id);
        Task RemoveRoomAsync(Room room);
        Task UpdateRoomAsync(Room room);
        Task<IEnumerable<Room>> GetRoomsForTagAsync(Guid tagId);
    }
}
