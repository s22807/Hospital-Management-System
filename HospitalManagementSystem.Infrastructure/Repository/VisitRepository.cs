using HospitalManagementSystem.Data;
using HospitalManagementSystem.Application.Repositories;
using HospitalManagementSystem.Domain.Models.Department;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Repository
{
    public class VisitRepository : IVisitRepository
    {
        private readonly ApplicationDbContext _context;

        public VisitRepository(ApplicationDbContext context) 
            => _context = context;

        public async Task CreateVisitAsync(Visit visit)
        {
            await _context.Visits.AddAsync(visit);
        }

        public async Task<Visit> GetAsync(Guid id)
        {
            var visit = await _context.Visits
                .Include(x => x.Doctor)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (visit == null)
            {
                throw new Exception($"Visit with id: {id} not found!");
            }

            return visit;
        }


        public async Task UpdateAsync(Visit visit)
        {
            _context.Visits.Update(visit);
            await _context.SaveChangesAsync();
        }
    }
}
