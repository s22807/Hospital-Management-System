using HospitalManagementSystem.Data;
using HospitalManagementSystem.Application.Repositories;
using HospitalManagementSystem.Domain.Models.People;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Repository
{
    internal class PatientRepository : IPatientRepository
	{
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
            => _context = context;

        public async Task AddAsync(Patient patient)
        {
            if (await GetAsync(patient.Id) == null)
            {
                await _context.AddAsync(patient);
                await _context.SaveChangesAsync();
            }

        }

        public async Task Delete(Guid patientId)
        {
            var p = await GetAsync(patientId);
            p.Delete(); //logical deletion
            await _context.SaveChangesAsync();
        }

        public async Task<Patient?> GetAsync(Guid patientId)
            => await _context.Patients.FindAsync(patientId);


        public async Task<IEnumerable<Patient>> GetPatientsAsync()
            => await _context.Patients.ToListAsync();

        public async Task Remove(Guid patientId)
        {
            var p = await GetAsync(patientId);
            if (p != null)
            {
                _context.Patients.Remove(p);
                await _context.SaveChangesAsync();
            }
        }
    }
}