using HospitalManagementSystem.Application.Models;
using HospitalManagementSystem.Application.Repositories;
using HospitalManagementSystem.Domain.Models.Department;
using HospitalManagementSystem.Domain.Models.People;
using System.Linq;

namespace HospitalManagementSystem.Application.Services
{
    public interface IDepartmentService
    {
        Task CreateDepartmentAsync(string name);
        Task<IEnumerable<DepartmentDTO>> GetDepartmentsAsync();
        Task<DepartmentDetailsDTO> GetDepartmentDetailsAsync(Guid id);
        Task AddRoomAsync(int roomNumber, Guid departmentId);
        Task RemoveRoomAsync(Guid roomId);
        Task TagRoom(Guid roomId, Guid tagId);
        Task<IEnumerable<PersonDTO>> PeopleReport();
        Task<int> SalarySum(Guid deptId);
    }
    internal class DepartmentService : IDepartmentService
    {

        private readonly IDepartmentRepository _departmentRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPatientRepository _patientRepository;
        public DepartmentService(IDepartmentRepository departmentRepository, ITagRepository tagRepository, IEmployeeRepository employeeRepository, IPatientRepository patientRepository)
        {
            _departmentRepository = departmentRepository;
            _tagRepository = tagRepository;
            _employeeRepository = employeeRepository;
            _patientRepository = patientRepository;
        }

        public async Task CreateDepartmentAsync(string name)
        {
            
            var department = new Department(name);
            await _departmentRepository.CreateDepartmentAsync(department);
        }

        public async Task<IEnumerable<DepartmentDTO>> GetDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetDepartmentsAsync();
            
            var departmentsDTO = departments.Select(x=>new DepartmentDTO(x));
            return departmentsDTO;
        }
        public async Task<DepartmentDetailsDTO> GetDepartmentDetailsAsync(Guid id)
        {
            var department = await _departmentRepository.GetDepartmentDetailsAsync(id);
            department.Rooms = department.Rooms.OrderBy(x => x.Number).ToList();
            var departmentsDTO = new DepartmentDetailsDTO(department);
            return departmentsDTO;
        }
        public async Task AddRoomAsync(int roomNumber, Guid departmentId)
        {
            var department = await _departmentRepository.GetDepartmentDetailsAsync(departmentId);
            if (department.Rooms.Any(e => e.Number == roomNumber))
            {
                return;
            }
            var room = new Room(roomNumber, department);
            
            await _departmentRepository.CreateRoomAsync(room);
        }

        public async Task RemoveRoomAsync(Guid roomId)
        {
            var room = await _departmentRepository.GetRoomAsync(roomId);
            if (room == null)
                return;
            await _departmentRepository.RemoveRoomAsync(room);
        }

        public async Task TagRoom(Guid roomId, Guid tagId)
        {
            var room = await _departmentRepository.GetRoomAsync(roomId);
            var tag = await _tagRepository.GetTagAsync(tagId);
            if (room!=null && tag != null)
            {
                room.Tag = tag;
                await _departmentRepository.UpdateRoomAsync(room);
            }
        }

        public async Task<IEnumerable<PersonDTO>> PeopleReport()
        {
            var emps = await _employeeRepository.GetEmployeesAsync();
            var patients = await _patientRepository.GetPatientsAsync();
            var people = emps.Select(x => new PersonDTO(x)).Concat(patients.Select(x => new PersonDTO(x)));
            return people;
        }


        public async Task<int> SalarySum(Guid deptId)
        {
            var emps = await _employeeRepository.GetEmployeesByDepartment(deptId);
            var sum = emps.Sum(x => x.Salary);
            return sum;
        }


    }
}
