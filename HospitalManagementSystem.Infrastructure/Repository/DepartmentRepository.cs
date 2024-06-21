using HospitalManagementSystem.Data;
using HospitalManagementSystem.Application.Repositories;
using HospitalManagementSystem.Domain.Models.Department;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Repository
{
    internal class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
            => _context = context;

        public async Task CreateDepartmentAsync(Department department)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Department>> GetDepartmentsAsync()
            => await _context.Departments.ToListAsync();
        public async Task<Department> GetDepartmentDetailsAsync(Guid id)
        {
            var dept = await _context.Departments.Include(x => x.Employees).Include(x => x.Rooms).FirstAsync(x => x.Id == id);
            return dept;
        }

        public async Task<Department?> GetDepartmentAsync(Guid dept)
            => await _context.Departments.FindAsync(dept);

        public async Task<Room?> GetRoomAsync(Guid? roomId)
            => await _context.Rooms.FindAsync(roomId);

        public async Task CreateRoomAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRoomAsync(Room room)
        {
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoomAsync(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Room>> GetRoomsForTagAsync(Guid tagId)
            => await _context.Rooms.Where(e => e.TagId == tagId).ToListAsync();

    }
}
