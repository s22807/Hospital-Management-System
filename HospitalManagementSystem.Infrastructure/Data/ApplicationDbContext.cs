using HospitalManagementSystem.Domain.Models.Department;
using HospitalManagementSystem.Domain.Models.Payments;
using HospitalManagementSystem.Domain.Models.People;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);

                entity.HasData(new List<Department>()
                {
                    new Department("Childcare"),
                    new Department("Dentistry")
                });
            });
            modelBuilder.Entity<Employee>(e =>
            {
                e.ToTable("Employee");
                e.HasKey(e => e.Id);

                e.Property(e => e.FirstName).IsRequired();
                e.Property(e => e.LastName).IsRequired();
                e.Property(e => e.FireDate).IsRequired();
                e.Property(e => e.Salary).IsRequired();
                e.Property(e => e.VacationDays).IsRequired();
                e.Property(e => e.Role).HasConversion<int>();
                e.Property(e => e.HoursWorked);
                e.Property(e => e.Username);
                e.Property(e => e.Email);
                e.Property(e => e.Password);
                e.Property(e => e.VisitTime);
                e.HasOne(e => e.Department).WithMany(e => e.Employees).HasForeignKey(e => e.DepartmentId).OnDelete(DeleteBehavior.SetNull);
                //e.HasData(new List<Employee>()
                //{
                //    new Employee(Guid.Parse("00000000-0000-0000-0001-000000000001"), 2000, 4, new DateTime(2023, 12, 23), Guid.Parse("00000000-0000-0000-0002-000000000001"), "Jan", "Kowalski", "12345678901", new DateTime(1989,8,12), true),
                //    new Employee(Guid.Parse("00000000-0000-0000-0001-000000000002"), 1700, 4, new DateTime(2023, 12, 23), Guid.Parse("00000000-0000-0000-0002-000000000001"), "Stanislaw", "Goral", "12345678901", new DateTime(1989,6,12), true),
                //    new Employee(Guid.Parse("00000000-0000-0000-0001-000000000003"), 5000, 4, new DateTime(2023, 12, 23), Guid.Parse("00000000-0000-0000-0002-000000000001"), "Ignacy", "Rybak", "12345678901", new DateTime(1979,8,12), true)
                //});

            });

            modelBuilder.Entity<Room>(e =>
            {
                e.ToTable("Room");
                e.HasKey(e => e.Id);
                e.HasOne(e => e.Department).WithMany(e => e.Rooms).HasForeignKey(e => e.DepartmentId).OnDelete(DeleteBehavior.SetNull);
                e.HasOne(e => e.Tag).WithMany().HasForeignKey(e => e.TagId).OnDelete(DeleteBehavior.SetNull);
            });
            modelBuilder.Entity<Payment>(e =>
            {
                e.ToTable("Payment");
                e.HasKey(e => e.PaymentId);
                e.Property(e => e.CreatedAt).IsRequired();
                e.Property(e => e.Amount).IsRequired();
                e.HasOne(e => e.Bill).WithMany(e => e.Payments).HasForeignKey(e => e.BillId).OnDelete(DeleteBehavior.Cascade);
                e.HasOne(e => e.Patient).WithMany(e => e.Payments).HasForeignKey(e => e.PatientId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Bill>(e =>
            {
                e.ToTable("Bill");
                e.HasKey(e => e.BillId);
                e.Property(e => e.CreatedAt).IsRequired();
                e.Property(e => e.Amount).IsRequired();
                e.HasOne(e => e.Patient).WithMany(e => e.Bills).HasForeignKey(e => e.PatientId).OnDelete(DeleteBehavior.SetNull);
                e.HasOne(e => e.Visit).WithOne(e => e.Bill).HasForeignKey<Bill>(e => e.VisitId).OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Patient>(e =>
            {
                e.ToTable("Patient");
                e.HasKey(e => e.Id);
                e.Property(e => e.FirstName).IsRequired();
                e.Property(e => e.LastName).IsRequired();
                e.Property(e => e.BirthDate).IsRequired();
                e.Property(e => e.CreatedAt).IsRequired();
                e.Property(e => e.Sex).IsRequired();
                e.Property(e => e.Username);
                e.Property(e => e.Email);
                e.Property(e => e.Password);
                e.Property(e => e.Insured).IsRequired();
                // Seeding initial data
                e.HasData(
                    new Patient("John", "Doe", "12345678901", new DateTime(1980, 5, 15), true, true, null, null),
                    new Patient("Jane", "Doe", "10987654321", new DateTime(1990, 3, 25), false, true, null, null));
            });
            modelBuilder.Entity<Visit>(e =>
            {
                e.ToTable("Visit");
                e.HasKey(e => e.Id);
                e.Property(e => e.CreatedAt).IsRequired();
                e.Property(e => e.VisitStartDate).IsRequired();
                e.Property(e => e.PatientId).IsRequired();
                e.Property(e => e.Status).IsRequired();
                e.HasOne(e => e.Patient).WithMany(e => e.Visits).HasForeignKey(e => e.PatientId).OnDelete(DeleteBehavior.Cascade);
                e.HasOne(e => e.Room).WithMany(e => e.Visits).HasForeignKey(e => e.RoomId).OnDelete(DeleteBehavior.SetNull);
                e.HasOne(e => e.Doctor).WithMany(e => e.Visits).HasForeignKey(e => e.DoctorId).OnDelete(DeleteBehavior.SetNull);
                e.HasOne(e => e.Tag).WithMany().HasForeignKey(e => e.TagId).OnDelete(DeleteBehavior.SetNull);
                e.HasOne(e => e.Bill).WithOne(e => e.Visit).HasForeignKey<Visit>(e => e.BillId).OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Tag>(e =>
            {
                e.ToTable("Tag");
                e.HasKey(e => e.Id);
                e.Property(e => e.Name).IsRequired();
            });
            


        }



    }

}