using HospitalManagementSystem.Domain.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.Models
{
    public class UserDTO
    {
        public UserDTO(User e)
        {
            Id = e.Id;
            Username = e.Username;
            Email = e.Email;
            Password = e.Password;
            Role = e.Role;
        }
        public UserDTO(string name, string password)
        {
            try
            {
                MailAddress m = new MailAddress(name);
                Email = name;
            }
            catch (FormatException)
            {
                Username = name;
            }
            Password = password;
        }

        public Guid? Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
    }
}
