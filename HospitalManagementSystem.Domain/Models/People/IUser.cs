using System.Net.Mail;

namespace HospitalManagementSystem.Domain.Models.People

{ 
    public interface IUser
    {
        public static ICollection<String> loginRegistry { get; set; } = null!;
        public string Username
        {
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Trim().Length > 0)
                {
                    if (loginRegistry.Contains(value))
                    {
                        throw new ArgumentException("Login already exists");
                    }
                    else
                    {
                        try
                        {
                            loginRegistry.Remove(this.Username);
                            this.Username = value;
                            loginRegistry.Add(value);
                        } catch
                        {
                              throw new ArgumentException("Login already exists");
                        }
                        
                    }
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
        public string Password {
            get
            {
                return Password;
            }
            set { 
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
        public string Email {
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
        public DateTime CreatedAt { get; }
        public DateTime DeletedAt { get; }
        public DateTime LoggedAt { get; }
        public void Login(IUser u);
        public void Delete();

    }
}
