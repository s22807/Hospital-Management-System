using HospitalManagementSystem.Application.Models;
using HospitalManagementSystem.Application.Repositories;
using HospitalManagementSystem.Domain.Models.People;
using System.Data;

namespace HospitalManagementSystem.Application.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployeesAsync();
        Task<EmployeeDTO?> GetEmployeeByIdAsync(Guid id);
        Task CreateEmployeeAsync(CreateEmployeeDTO employeeCreateDTO);
        Task RemoveEmployeeAsync(Guid employeeId);
        Task TagEmployee(Guid employeeId, Guid tagId);
        Task UpdateEmployee(EmployeeDTO employeeDTO);
    }
    internal class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ITagRepository _tagRepository;
        public EmployeeService(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository, ITagRepository tagRepository = null)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _tagRepository = tagRepository;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployeesAsync()
        {
            var employees = await _employeeRepository.GetEmployeesAsync();
            var empDTO = employees.Select(x => new EmployeeDTO(x));
            return empDTO;
        }

        public async Task<EmployeeDTO?> GetEmployeeByIdAsync(Guid id)
        {
            var e = await _employeeRepository.GetEmployeeAsync(id);
            if (e == null)
            {
                return null;
            }
            return new EmployeeDTO(e);
        }
        public async Task CreateEmployeeAsync(CreateEmployeeDTO employeeCreateDTO)
        {
            var dept = await _departmentRepository.GetDepartmentDetailsAsync(employeeCreateDTO.DepartmentId);
            IEmpRole.Role empKind;
            Enum.TryParse(employeeCreateDTO.EmpKind, out empKind);

            var emp = new Employee(employeeCreateDTO.Salary, DateTime.Now.AddYears(2), dept, empKind,
                employeeCreateDTO.FirstName, employeeCreateDTO.LastName, employeeCreateDTO.Pesel, employeeCreateDTO.BirthDate, employeeCreateDTO.Sex, employeeCreateDTO.VisitTime);
            await _employeeRepository.Add(emp);
        }

        public async Task RemoveEmployeeAsync(Guid employeeId)
        {
            var emp = await _employeeRepository.GetEmployeeAsync(employeeId);
            if (emp == null)
            {
                return;
            }
            await _employeeRepository.Remove(emp);
        }
        public async Task UpdateEmployee(EmployeeDTO employeeDTO)
        {
            var employee = await _employeeRepository.GetEmployeeAsync(employeeDTO.Id);
            if (employee == null) throw new Exception("Employee not found.");
            employee.SetFirstname(employeeDTO.FirstName);
            employee.SetLastname(employeeDTO.LastName);
            employee.SetPesel(employeeDTO.Pesel);
            employee.Sex = employeeDTO.Sex;
            employee.SetSalary(employeeDTO.Salary);
            employee.SetVacationDays(employeeDTO.VacationDays);
            employee.SetFireDate(employeeDTO.FireDate);
            employee.SetBirthDate(employeeDTO.Birthdate);
            employee.SetVisitTime(employeeDTO.VisitTime);
            employee.SetRole((IEmpRole.Role)Enum.Parse(typeof(IEmpRole.Role), employeeDTO.EmpKind));
            await _employeeRepository.UpdateEmployeeAsync(employee);
        }

        public async Task TagEmployee(Guid employeeId, Guid tagId)
        {
            var employee = await _employeeRepository.GetEmployeeAsync(employeeId);
            var tag = await _tagRepository.GetTagAsync(tagId);
            if (employee != null && tag != null) {
                employee.SetTag(tag);
                await _employeeRepository.UpdateEmployeeAsync(employee);
            }
        }
    }
}
