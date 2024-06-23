using HospitalManagementSystem.Domain.Models.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.Repositories
{
    public interface IPaymentsRepository
    {
        Task PayForBillAsync(Guid billId, double value);
        Task<double> GetDebtForPatientAsync(Guid patientId);
        Task CreateBill(Bill? bill);
    }
}
