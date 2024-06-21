namespace HospitalManagementSystem.Domain.Models.People
{
    public abstract class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; } 
        public string Pesel { get; private set; }

        public DateTime BirthDate { get; protected set; }

        public bool Sex { get; private set; }

        public Person(string firstName, string lastName, string pesel, DateTime birthDate, bool sex)
        {
            SetFirstname(firstName);
            SetLastName(lastName);
            Pesel = pesel;
            SetBirthDate(birthDate);
            Sex = sex;
        }
        public Person(string firstName, string lastName, string pesel, bool sex)
        {
            SetFirstname(firstName);
            SetLastName(lastName);
            Pesel = pesel;
            Sex = sex;
        }

        private void SetFirstname(string value)
        {
            if (!string.IsNullOrEmpty(value) && value.Trim().Length > 0)
            {
                FirstName = value;
            }
            else
            {
                throw new ArgumentException("Firstname cannot be empty or null");
            }
        }

        private void SetLastName(string value)
        {
            if (!string.IsNullOrEmpty(value) && value.Trim().Length > 0)
            {
                LastName = value;
            }
            else
            {
                throw new ArgumentException("Lastname cannot be empty or null");
            }
        }

        private void SetBirthDate(DateTime value)
        {
            if (value > new DateTime(1900, 1, 1, 0, 0, 0))
            {
                BirthDate = value.Date;
            }
            else
            {
                throw new ArgumentException("Birthdate cannot be before 1900");
            }
        }

        public int GetAge() => DateTime.Now.Year - BirthDate.Year;
    }
}

