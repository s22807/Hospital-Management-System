using HospitalManagementSystem.Application.Repositories;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Domain.Models.Payments;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Repository
{
    internal class PaymentsRepository : IPaymentsRepository
    {
        private readonly ApplicationDbContext _context;
        public PaymentsRepository(ApplicationDbContext context) {
            _context = context;
        }
        public async Task CreateBill(Bill bill)
        {
            _context.Bills.Add(bill);
        }
        public async Task PayForBillAsync(Guid billId, double value)
        {
            var bill = await _context.Bills.Include(e=>e.Payments).Include(e=>e.Patient).Include(e=>e.Visit).FirstOrDefaultAsync(e => e.BillId == billId);
            if (bill != null && !bill.IsPaid && bill.Visit.Status != "Cancelled")
            {
                var payment = new Payment(bill.Patient, bill, value);
                _context.Payments.Add(payment);
                
                bill.PaidAmount += value;
                if (bill.PaidAmount >= bill.Amount)
                {
                    bill.IsPaid = true;
                    var v = _context.Visits.Where(e => e.Id == bill.VisitId).First();
                    v.Status = v.Status == "Completed" ? "Closed" : "Paid";
                }
                
                 
                _context.Bills.Update(bill);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<double> GetDebtForPatientAsync(Guid patientId)
        {
            return await _context.Bills
                                 .Where(b => b.PatientId == patientId && b.Amount > b.PaidAmount)
                                 .SumAsync(b => b.Amount - b.PaidAmount);
        }
    }
}
