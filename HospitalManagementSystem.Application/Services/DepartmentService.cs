using HospitalManagementSystem.Application.Models;
using HospitalManagementSystem.Application.Repositories;
using HospitalManagementSystem.Domain.Models.Department;
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
    }
    internal class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
            => _departmentRepository = departmentRepository;

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

        
    }
}
