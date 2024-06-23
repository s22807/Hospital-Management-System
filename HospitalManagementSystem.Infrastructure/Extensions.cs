using HospitalManagementSystem.Data;
using HospitalManagementSystem.Application.Repositories;
using HospitalManagementSystem.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagementSystem.Infrastructure
{
    public static class Extensions
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            serviceCollection
                .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer((connectionString),
                b => b.MigrationsAssembly("HospitalManagementSystem.Infrastructure")))
                .AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            return serviceCollection.AddScoped<IPatientRepository, PatientRepository>()
                .AddScoped<IEmployeeRepository, EmployeeRepository>()
                .AddScoped<IDepartmentRepository, DepartmentRepository>()
                .AddScoped<IVisitRepository, VisitRepository>()
                .AddScoped<ITagRepository, TagRepository>()
                .AddScoped<IPaymentsRepository, PaymentsRepository>();
        }
	}
}

