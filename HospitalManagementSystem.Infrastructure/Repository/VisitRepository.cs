using HospitalManagementSystem.Data;
using HospitalManagementSystem.Application.Repositories;
using HospitalManagementSystem.Domain.Models.Department;
using Microsoft.EntityFrameworkCore;
using static HospitalManagementSystem.Domain.Models.People.Employee;
using HospitalManagementSystem.Domain.Models.People;

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
            await _context.SaveChangesAsync();
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

        public async Task<IEnumerable<Visit>> GetPatientsVisitsAsync(Guid patientId)
        {
            return await _context.Visits
                .Include(x => x.Doctor)
                .Include(x => x.Room)
                .Where(x => x.PatientId == patientId)
                .ToListAsync();
        }

        public async Task<IEnumerable<VisitSlot>> GetFreeSlots(Tag tag)
        {
            if (tag == null) throw new Exception("Tag not provided");
            var doctors = await _context.Employees.Where(e => e.Role == IEmpRole.Role.Doctor && e.TagId == tag.Id).ToListAsync();
            var rooms = await _context.Rooms.Where(e => e.TagId == tag.Id).ToListAsync();
            var reservedSlots = await _context.Visits.Where(e => e.TagId == tag.Id).ToListAsync();

            if(doctors.Count==0 || rooms.Count == 0)
            {
                throw new Exception($"NO ROOMS OR DOCTORS FOR TAG {tag.Name}");
            }
            // Iterate until 4 PM (16:00)
            var availableSlots = new List<VisitSlot>();
            do
            {
                var slotStartTime = DateTime.Today.AddDays(1).AddHours(8);
                
                foreach (var doctor in doctors)
                {
                    double visitTimed = (double)doctor.VisitTime;
                    var slotEndTime = slotStartTime.AddMinutes(visitTimed); // Use doctor's visit time

                    // Iterate through each time slot using doctor's visit time
                    while (slotEndTime <= slotStartTime.Date.AddHours(16)) // Iterate till 4 PM
                    {
                        var doctorHasVisit = reservedSlots.Any(visit =>
                            visit.DoctorId == doctor.Id &&
                            visit.VisitStartDate < slotEndTime &&
                            visit.VisitStartDate.AddMinutes(visitTimed) > slotStartTime);

                        if (!doctorHasVisit)
                        {
                            foreach (var room in rooms)
                            {
                                var slotOccupied = reservedSlots.Any(visit =>
                                    visit.RoomId == room.Id &&
                                    visit.VisitStartDate < slotEndTime &&
                                    visit.VisitStartDate.AddMinutes(visitTimed) > slotStartTime);

                                if (!slotOccupied)
                                {
                                    availableSlots.Add(new VisitSlot(
                                        doctor, room, slotStartTime, slotEndTime, tag
                                        ));
                                    break;
                                }
                            }
                        }

                        // Move to the next slot based on the doctor's visit time
                        slotStartTime = slotEndTime;
                        slotEndTime = slotStartTime.AddMinutes((double)doctor.VisitTime);
                    }
                }
                slotStartTime = slotStartTime.Date.AddDays(1).AddHours(8);
            } while (availableSlots.Count < 10);
            return availableSlots;


        }

        public async Task<IEnumerable<Visit>> GetVisitSince(DateTime now)
            => await _context.Visits.Where(e => e.VisitStartDate > now)
            .Include(e => e.Doctor)
            .Include(e => e.Room)
            .Include(e => e.Tag)
            .ToListAsync();


        public async Task UpdateAsync(Visit visit)
        {
            _context.Visits.Update(visit);
            await _context.SaveChangesAsync();
        }
    }


}

