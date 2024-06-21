using HospitalManagementSystem.Application.Repositories;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Domain.Models.People;
using Microsoft.EntityFrameworkCore;
using static HospitalManagementSystem.Domain.Models.People.Employee;

namespace HospitalManagementSystem.Infrastructure.Repository
{
    internal class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var patientUsers = await _context.Patients.Where(e => e.Email != null && e.Username != null && e.Password != null)
                .Select(e => new User(e)).ToListAsync();
            var employeeUsers = await _context.Employees.Where(e => e.Email != null && e.Username != null && e.Password != null)
                .Select(e => new User(e)).ToListAsync();
            return patientUsers.Concat(employeeUsers);
        }
        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            var user = await _context.Patients.Select(e => new User(e))
                .Concat(_context.Employees.Select(e => new User(e)))
                .Where(e => e.Username == username).FirstAsync();
            
            return user;
        }
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            var user = await _context.Patients.Select(e => new User(e))
                .Concat(_context.Employees.Select(e => new User(e)))
                .Where(e => e.Email == email).FirstAsync();
            
            return user;
        }
        public async Task<IUser> GetSpecificUser(IUser user)
        {

            if (CheckRole(user.Role))
            {
                return await _context.Employees.FindAsync(user.Id);
            }
            else
            {
                return await _context.Patients.FindAsync(user.Id);
            }
        }
        public async Task EditUser(string username, IUser user)
        {
            IUser? userToChange = await GetUserByUsernameAsync(username);


            if (userToChange != null)
            {
                userToChange = await GetSpecificUser(userToChange);
                userToChange.Password = user.Password;
                userToChange.Email = user.Email;
                //if (CheckRole(userToChange.Role))
                //{
                //    var employee = await _context.Employees.FindAsync(user.Id);
                //    employee.Password = user.Password;
                //    employee.Email = user.Email;
                //}
                //else
                //{
                //    var patient = await _context.Patients.FindAsync(user.Id);
                //    patient.Password = user.Password;
                //    patient.Email = user.Email;
                //}
                await _context.SaveChangesAsync();
            }
        }
        public async Task LoginUser(string username)
        {
            IUser? user = await GetUserByUsernameAsync(username);
            if (user != null)
            {
                user = await GetSpecificUser(user);
                user.Login();
                await _context.SaveChangesAsync();
            }
        }

        
    }
}
