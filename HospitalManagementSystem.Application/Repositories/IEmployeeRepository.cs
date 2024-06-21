using HospitalManagementSystem.Domain.Models.People;

namespace HospitalManagementSystem.Application.Repositories
{
    public interface IEmployeeRepository
    {
        Task Add(Employee emp);
        Task<IEnumerable<Employee>> GetDoctorsForTagAsync(Guid tagId);
        Task<Employee?> GetEmployeeAsync(Guid id);
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task Remove(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
    }
}
