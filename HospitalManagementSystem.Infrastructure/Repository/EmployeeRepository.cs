using HospitalManagementSystem.Data;
using HospitalManagementSystem.Application.Repositories;
using HospitalManagementSystem.Domain.Models.People;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Repository
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
            => _context = context;

        public async Task Add(Employee emp){
            await _context.Employees.AddAsync(emp);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee?> GetAsync(Guid? empId)
            => await _context.Employees.FindAsync(empId);

        public async Task<Employee?> GetEmployeeByIdAsync(Guid id)
            => await _context.Employees.FindAsync(id);

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
            => await _context.Employees.ToListAsync();

        public async Task Remove(Employee employee){
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}
