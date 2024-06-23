using HospitalManagementSystem.Application.Repositories;
using HospitalManagementSystem.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagementSystem.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            return service.AddScoped<IPatientService, PatientService>()
                .AddScoped<IEmployeeService, EmployeeService>()
                .AddScoped<IVisitService, VisitService>()
                .AddScoped<IDepartmentService, DepartmentService>()
                .AddScoped<ITagService, TagService>()
                ;
        }
    }
}



//provider.GetRequiredService<IVisitRepository>(),
//                                                                                    provider.GetRequiredService<IEmployeeRepository>(),
//                                                                                    provider.GetService<IPatientRepository>(),
//                                                                                    provider.GetService<IDepartmentRepository>(),