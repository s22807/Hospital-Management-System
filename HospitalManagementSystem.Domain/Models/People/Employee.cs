using HospitalManagementSystem.Domain.Models.Department;
using HospitalManagementSystem.Domain.Models.Department;

namespace HospitalManagementSystem.Domain.Models.People
{

    public class Employee : Person, IUser
    {
        public enum EmpKind
        {
            Trainee = 0,
            Receptionist = 1,
            Doctor = 2,
            Admin = 3
        }
        public static bool CheckRole(string roleToCheck)
        {
            return Enum.TryParse(roleToCheck, out EmpKind result);
        }

        public Guid Id { get; private set; }
        public int Salary { get; private set; }
        public int VacationDays { get; private set; }
        public DateTime FireDate { get; private set; }
        public EmpKind Role { get; private set; }
        string IUser.Role => Role.ToString();
        public Guid? DepartmentId { get; private set; }
        public Guid? TagId { get; private set; }
        public virtual Department.Department? Department { get; private set; }
        public virtual ICollection<Visit> Visits { get; private set; } 
        public virtual ICollection<Room.Key> RentedKeys { get; private set; } = new List<Room.Key>();
        public virtual Tag? Tag { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public DateTime? LoggedAt { get; private set; }
        public string? Email;
        public string? Username;
        public string? Password;
        public void Login()
        {
            this.LoggedAt = DateTime.Now;
        }
        public void Delete()
        {
            this.DeletedAt = DateTime.Now;
        }
        public int? VisitTime { get; private set; } //in minutes
        public int? HoursWorked { get; private set; }
        private static int TrainingTime = 80;

        public static int DefaultVaccationDays = 2;
        //public static DateTime = DateTime.Now.AddYears(2);

        public Employee(int salary, DateTime fireDate, Department.Department? department, EmpKind role
            , string firstName, string lastName, string pesel, DateTime birthDate, bool sex, int? visitTime)
            : base(firstName, lastName, pesel, birthDate, sex)
        {
            Id = Guid.NewGuid();
            SetSalary(salary);
            SetVacationDays(DefaultVaccationDays);
            SetFireDate(fireDate);
            SetDepartment(department);
            SetRole(role);
            SetBirthDate(birthDate);
            SetVisitTime(visitTime);
        }
        public Employee(int salary, DateTime fireDate, EmpKind role
            , string firstName, string lastName, string pesel, DateTime birthDate, bool sex, int? visitTime)
            : base(firstName, lastName, pesel, birthDate, sex)
        {
            Id = Guid.NewGuid();
            SetSalary(salary);
            SetVacationDays(DefaultVaccationDays);
            SetFireDate(fireDate);
            
            SetRole(role);
            SetBirthDate(birthDate);
            SetVisitTime(visitTime);
        }
        //public Employee(Guid empId, int salary, int vacationDays, DateTime fireDate, Department.Department? department
        //    , string firstName, string lastName, string pesel, DateTime birthDate, bool sex, int? visitTime)
        //    : base(firstName, lastName, pesel, sex)
        //{
        //    Id = empId;
        //    SetSalary(salary);
        //    SetVacationDays(vacationDays);
        //    SetFireDate(fireDate);
        //    SetDepartment(department);
        //    SetRole(EmpKind.Trainee);
        //    SetBirthDate(birthDate);
        //    SetVisitTime(visitTime);
        //}
        //private Employee(int salary, int vacationDays, DateTime fireDate
        //    , string firstName, string lastName, string pesel, DateTime birthDate, bool sex, int? visitTime)
        //    : base(firstName, lastName, pesel, sex)
        //{
        //    Id = Guid.NewGuid();
        //    SetSalary(salary);
        //    SetVacationDays(vacationDays);
        //    SetFireDate(fireDate);
        //    SetBirthDate(birthDate);
        //    SetRole(EmpKind.Trainee);
        //    SetVisitTime(visitTime);
        //}
        //private Employee(Guid empId, int salary, int vacationDays, DateTime fireDate
        //    , string firstName, string lastName, string pesel, DateTime birthDate, bool sex, int? visitTime)
        //    : base(firstName, lastName, pesel, sex)
        //{
        //    Id = empId;
        //    SetSalary(salary);
        //    SetVacationDays(vacationDays);
        //    SetFireDate(fireDate);
        //    SetBirthDate(birthDate);
        //    SetRole(EmpKind.Trainee);
        //    SetVisitTime(visitTime);
        //}
        public void SetSalary(int value)
        {
            if (value > 0)
            {
                Salary = value;
            }
            else
            {
                throw new ArgumentException("Salary cannot be below 0.");
            }
        }
        public void SetVacationDays(int value)
        {
            if (value > 0)
            {
                VacationDays = value;
            }
            else
            {
                throw new ArgumentException("Vacation days cannot be below 0.");
            }
        }
        public void SetFireDate(DateTime value)
        {
            if (value > DateTime.Now)
            {
                FireDate = value;
            }
            else
            {
                throw new ArgumentException("Fire date cannot be in the past.");
            }
        }

        public void SetRole(EmpKind value)
        {
            if (this.FireDate < DateTime.Now)
            {
                throw new ArgumentException("Cannot change role of an employee that is fired.");
            }
            Role = value;
        }

        public void SetDepartment(Department.Department? value)
        {
            if (this.Department != value)
            {
                if (this.Department != null)
                    this.Department.RemoveEmployee(this);
                Department = value;
                if (value != null && !value.Employees.Contains(this))
                {
                    value.AddEmployee(this);
                }
            }
        }
        public void AddKey(Room.Key value)
        {
            if (!this.RentedKeys.Contains(value))
            {
                if (this.RentedKeys.Count >= 3)
                {
                    throw new ArgumentException("Employee cannot have more than 3 keys.");
                }
                this.RentedKeys.Add(value);
                value.Employee = this;
            }
        }
        public void RemoveKey(Room.Key value)
        {
            if (this.RentedKeys.Contains(value))
            {
                this.RentedKeys.Remove(value);
                value.Employee = null;
            }
        }

        public override void SetBirthDate(DateTime value)
        {
            if (value > new DateTime(1900, 1, 1, 0, 0, 0) && DateTime.Now.Year - value.Year > 16)
            {
                BirthDate = value.Date;
            }
            else
            {
                throw new ArgumentException("Birthdate cannot be before 1900 and age cannot be below 16.");
            }
        }

        public void SetTag(Tag tag)
        {
            Tag = tag;
        }
        public void SetVisitTime(int? time)
        {
            if(this.Role != EmpKind.Doctor)
            {
                return;
            }
            if (time > 0 && time < 60)
            {
                VisitTime = time;
            } else
            {
                throw new ArgumentException($"Unrealistic visit time {time}min");
            }
        }
        public void AddHoursWorked(int hours)
        {
            HoursWorked += hours;
            if (HoursWorked >= TrainingTime && Role == EmpKind.Trainee)
            {
                SetRole(EmpKind.Receptionist);
                SetSalary((int)(Salary * 1.2));
            }
        }

        //public DateTime backAtWorkDate { get; set; }
        //public TimeSpan timePracticed { get; set; }
        //public ICollection<Room> roomKeys { get; set; }
        //public ICollection<Visit> visits { get; set; } = null!;
        //public Guid deptId { get; set; }


    }
}
