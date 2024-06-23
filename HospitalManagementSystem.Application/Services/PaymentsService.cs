using HospitalManagementSystem.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.Services
{
    public interface IPaymentsService
    {
        Task PayForBillAsync(Guid billId, double value);
        Task<double> GetDebtForPatientAsync(Guid patientId);
    }

    internal class PaymentsService : IPaymentsService
    {
        private readonly IPaymentsRepository _paymentsRepository;

        public PaymentsService(IPaymentsRepository paymentsRepository)
        {
            _paymentsRepository = paymentsRepository;
        }

        public async Task PayForBillAsync(Guid billId, double value)
        {
            // Business logic for paying a bill can be added here
            await _paymentsRepository.PayForBillAsync(billId, value);
        }

        public async Task<double> GetDebtForPatientAsync(Guid patientId)
        {
            // Business logic for calculating patient's debt can be added here
            return await _paymentsRepository.GetDebtForPatientAsync(patientId);
        }
    }
}


