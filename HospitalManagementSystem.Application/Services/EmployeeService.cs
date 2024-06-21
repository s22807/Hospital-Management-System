using HospitalManagementSystem.Application.Models;
using HospitalManagementSystem.Application.Repositories;
using HospitalManagementSystem.Domain.Models.People;

namespace HospitalManagementSystem.Application.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployeesAsync();
        Task<EmployeeDTO?> GetEmployeeByIdAsync(Guid id);
        Task CreateEmployeeAsync(EmployeeCreateDTO employeeCreateDTO);
        Task RemoveEmployeeAsync(Guid employeeId);
    }
    internal class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository) {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployeesAsync()
        {
            var employees = await _employeeRepository.GetEmployeesAsync();
            var empDTO = employees.Select(x => new EmployeeDTO(x));
            return empDTO;
        }

        public async Task<EmployeeDTO?> GetEmployeeByIdAsync(Guid id)
        {
            var e = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (e == null)
            {
                return null;
            }
            return new EmployeeDTO(e);
        }
        public async Task CreateEmployeeAsync(EmployeeCreateDTO employeeCreateDTO)
        {
            var dept = await _departmentRepository.GetDepartmentDetailsAsync(employeeCreateDTO.DepartmentId);
            Employee.EmpKind empKind;
            Enum.TryParse(employeeCreateDTO.EmpKind, out empKind);

            var emp = new Employee(employeeCreateDTO.Salary, DateTime.Now.AddYears(2), dept, empKind,
                employeeCreateDTO.FirstName, employeeCreateDTO.LastName, employeeCreateDTO.Pesel, employeeCreateDTO.BirthDate, employeeCreateDTO.Sex);
            await _employeeRepository.Add(emp);
        }

        public async Task RemoveEmployeeAsync(Guid employeeId)
        {
            var emp = await _employeeRepository.GetAsync(employeeId);
            if (emp == null)
            {
                return;
            }
            await _employeeRepository.Remove(emp);
        }
    }
}
