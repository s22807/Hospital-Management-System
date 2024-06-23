using HospitalManagementSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentsService _paymentService;
        public PaymentController(IPaymentsService paymentsService)
        {
            _paymentService = paymentsService;
        }
        [HttpPost]
        public async Task<IActionResult> PayForBill(Guid billId, double value)
        {
            await _paymentService.PayForBillAsync(billId, value);
            return View(); // Assuming you have an index or list page to redirect to
        }
        [HttpGet]
        public async Task<IActionResult> GetDebtForPatient(Guid patientId)
        {
            var debt = await _paymentService.GetDebtForPatientAsync(patientId);
            return View(debt); // Pass the debt information to the view
        }
    }
}
