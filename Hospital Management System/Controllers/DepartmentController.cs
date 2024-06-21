using HospitalManagementSystem.Application.Models;
using HospitalManagementSystem.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
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
            
            return View(await GetDepartmentDetailsDTO(id));
        }

        // GET: DepartmentController/Create
        [HttpPost]
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
    }
}
