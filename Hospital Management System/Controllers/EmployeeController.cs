using HospitalManagementSystem.Application.Models;
using HospitalManagementSystem.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService) {
            _employeeService = employeeService;
        }
        public Task<IEnumerable<EmployeeDTO>> GetEmployees()
            => _employeeService.GetEmployeesAsync();
        // GET: EmployeeController
        public async Task<ActionResult> Index()
        {
            //ViewData["Employees"] = ;
            return View(await GetEmployees());
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        [HttpGet]
        public ActionResult Create(Guid departmentId)
        {
            return View(new EmployeeCreateDTO { DepartmentId= departmentId });
        }

        // POST: EmployeeController/Create
        [HttpPost]
        public async Task<ActionResult> Create(EmployeeCreateDTO empDTO)
        {
            await _employeeService.CreateEmployeeAsync(empDTO);
            return RedirectToAction("Details", "Department", new {id = empDTO.DepartmentId});
        }

        // GET: EmployeeController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var emp = await _employeeService.GetEmployeeByIdAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: EmployeeController/Re/5
        
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Remove(Guid employeeId)
        {
            await _employeeService.RemoveEmployeeAsync(employeeId);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Remove(Guid employeeId, Guid departmentId)
        {
            await _employeeService.RemoveEmployeeAsync(employeeId);
            return RedirectToAction("Details", "Department", new {id = departmentId});
        }
    }
}
