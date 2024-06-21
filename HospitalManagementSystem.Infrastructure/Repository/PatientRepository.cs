using HospitalManagementSystem.Data;
using HospitalManagementSystem.Application.Repositories;
using HospitalManagementSystem.Domain.Models.People;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HospitalManagementSystem.Infrastructure.Repository
{
    internal class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
            => _context = context;

        public async Task AddAsync(Patient patient)
        {
            if (await GetPatientAsync(patient.Id) == null)
            {
                await _context.AddAsync(patient);
                await _context.SaveChangesAsync();
            }

        }

        public async Task Delete(Guid patientId)
        {
            var p = await GetPatientAsync(patientId);
            p.Delete(); //logical deletion
            await _context.SaveChangesAsync();
        }

        public async Task<Patient?> GetPatientAsync(Guid patientId)
            => await _context.Patients.FindAsync(patientId);


        public async Task<IEnumerable<Patient>> GetPatientsAsync()
            => await _context.Patients.ToListAsync();

        public async Task<IEnumerable<Patient>> GetPatientsAsync(string? firstname, string? lastname, string? pesel)
        {
            var query = _context.Patients;
            if (!firstname.IsNullOrEmpty()) query.Where(e => e.FirstName == firstname);
            if (!lastname.IsNullOrEmpty()) query.Where(e => e.LastName == lastname);
            if (!pesel.IsNullOrEmpty()) query.Where(e => e.Pesel == pesel);
            return await query.ToListAsync();
        }

        public async Task Remove(Guid patientId)
        {
            var p = await GetPatientAsync(patientId);
            if (p != null)
            {
                _context.Patients.Remove(p);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Update(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }
    }
}