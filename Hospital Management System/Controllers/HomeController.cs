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
        private readonly IUserService _userService;
        public HomeController(IPatientService patientService, IEmployeeService employeeService, IUserService userService)
        {
            _patientService = patientService;
            _employeeService = employeeService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            if (TempData["user"] == null)
            {
                var users = await _userService.GetUsersAsync();
                return View(users);
            }
            else
            {
                UserDTO user = await _userService.GetUserByNameAsync((TempData["user"] as UserDTO).Username);
                if (user == null)
                {
                    TempData["user"] = null;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["role"] = user.Role;
                    if (user.Role == "Patient")
                    {
                        return RedirectToAction("Details", "Patient", user.Id);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Visit");
                    }
                }
            }
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserDTO userDTO)
        {
            try
            {
                var user = await _userService.LoginUserAsync(userDTO);
                TempData["user"] = user;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}