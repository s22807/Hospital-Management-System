using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using System.Net.Mail;

namespace HospitalManagementSystem.Domain.Models.People

{
    public interface IUser
    {

        public string Username
        {
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Trim().Length > 0)
                {
                    this.Username = value;
                }
                else
                {
                    throw new ArgumentException("Login cannot be empty or null");
                }
            }
            get
            {
                return Username;
            }
        }
        public string Password
        {
            get
            {
                return Password;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Trim().Length == 0)
                {
                    throw new ArgumentException("Password cannot be empty or null");
                }
                else
                {
                    Password = value;
                }
            }
        }
        public string Email
        {
            get
            {
                return Email;
            }
            set
            {
                try
                {
                    MailAddress m = new MailAddress(value);
                }
                catch (FormatException)
                {
                    throw new ArgumentException("Email is not valid");
                }
                Email = value;
            }
        }
        public Guid Id { get; }
        public DateTime? DeletedAt { get; }
        public DateTime? LoggedAt { get; }
        public string Role { get; }
        public void Login();
        public void Delete();
        public virtual void Register(IUser user, string username, string password, string email)
        {

            user.Username = username;
            user.Password = password;
            user.Email = email;
        }

    }
    public class User : IUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime? DeletedAt { get; private set; }
        public DateTime? LoggedAt { get; private set; }
        public void Login()
        {
            this.LoggedAt = DateTime.Now;
        }
        public void Delete()
        {
            this.DeletedAt = DateTime.Now;
        }
        public User(IUser user)
        {
            Id = user.Id;
            DeletedAt = user.DeletedAt;
            LoggedAt = user.LoggedAt;
            Username = user.Username;
            Password = user.Password;
            Email = user.Email;
            Role = user.Role;
        }


    }
}
