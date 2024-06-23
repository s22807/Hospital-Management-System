using HospitalManagementSystem.Application;
using HospitalManagementSystem.Application.Models;
using HospitalManagementSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HospitalManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IEmployeeService _employeeService;

        public HomeController(IPatientService patientService, IEmployeeService employeeService)
        {
            _patientService = patientService;
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}