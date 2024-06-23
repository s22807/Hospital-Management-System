using HospitalManagementSystem.Application.Models;
using HospitalManagementSystem.Application.Services;
using HospitalManagementSystem.Domain.Models.Department;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;
        private readonly ITagService _tagService;
        public DepartmentController(IDepartmentService departmentService, ITagService tagService, IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
            _tagService = tagService;
        }
        public Task<IEnumerable<DepartmentDTO>> GetDepartments()
            => _departmentService.GetDepartmentsAsync();
        public Task<DepartmentDetailsDTO> GetDepartmentDetailsDTO(Guid id)
            => _departmentService.GetDepartmentDetailsAsync(id);
        // GET: DepartmentController
        public async Task<ActionResult> Index()
        {
            var departments = await GetDepartments();
            return View(departments);
        }

        // GET: DepartmentController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            ViewBag.Tags = await _tagService.GetTagsAsync();
            return View(await GetDepartmentDetailsDTO(id));
        }

        // GET: DepartmentController/Create
        
        public async Task<ActionResult> Create(string name)
        {
            await _departmentService.CreateDepartmentAsync(name);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<ActionResult> AddRoom(int roomNumber, Guid departmentId)
        {
            await _departmentService.AddRoomAsync(roomNumber, departmentId);
            return RedirectToAction("Details", "Department", new { id = departmentId });
        }
        [HttpPost]
        public async Task<ActionResult> RemoveRoom(Guid roomId, Guid departmentId)
        {
            await _departmentService.RemoveRoomAsync(roomId);
            return RedirectToAction("Details", "Department", new { id = departmentId });
        }
        [HttpPost]
        public async Task<ActionResult> TagRoom(Guid roomId, Guid departmentId, Guid tagId)
        {
            await _departmentService.TagRoom(roomId, tagId);
            return RedirectToAction("Details", "Department", new { id = departmentId });
        }

        [HttpGet]
        public async Task<ActionResult> PeopleReport(Guid empId)
        {
            var emp = await _employeeService.GetEmployeeByIdAsync(empId);
            if (emp.EmpKind == "Admin")
            {
                var people = await _departmentService.PeopleReport();
                return Json(people);
            }
            else
            {
                throw new Exception("Employee does not have permission to generate report");
            }
        }
        [HttpGet]
        public async Task<ActionResult> FinanceReport(Guid empId, Guid deptId)
        {
            var emp = await _employeeService.GetEmployeeByIdAsync(empId);
            if (emp.EmpKind == "Admin")
            {
                var salarySum = await _departmentService.SalarySum(deptId);
                return Json(salarySum);
            }
            else
            {
                throw new Exception("Employee does not have permission to generate report");
            }
        }

    }
}
