using HospitalManagementSystem.Domain.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User?> GetUserByUsernameAsync(string username);
        Task EditUser(string username, IUser user);
        Task LoginUser(string username);
        Task<User?> GetUserByEmailAsync(string email);
    }
}
