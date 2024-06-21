using HospitalManagementSystem.Domain.Models.People;

namespace HospitalManagementSystem.Application.Repositories
{
    public interface IEmployeeRepository
    {
        Task Add(Employee emp);
        Task<Employee?> GetAsync(Guid? doctorId);
        Task<Employee?> GetEmployeeByIdAsync(Guid id);
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task Remove(Employee employee);
    }
}
