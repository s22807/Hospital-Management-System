using HospitalManagementSystem.Application.Models;
using HospitalManagementSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
            => _patientService = patientService;

        public async Task<IEnumerable<PatientDTO>> GetPatientsAsync()
            => await _patientService.GetPatientsAsync();

        [HttpGet]
        // GET: PatientController
        public async Task<IActionResult> Index()
        {
            var patients = await GetPatientsAsync();

            return View(patients);
        }

        // GET: PatientController/Details/5
        public async Task<ActionResult> Details(Guid Id)
        {
            var patient = await _patientService.GetPatientDetailsAsync(Id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // GET: PatientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreatePatientDTO patient)
        {
            try
            {
                await _patientService.CreatePatientAsync(patient);
            } catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            
            return RedirectToAction(nameof(Index));
        }

        // GET: PatientController/Edit/5
        public async Task<ActionResult> Edit(Guid Id)
        {
            var patient = await _patientService.GetPatientDetailsAsync(Id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: PatientController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Guid patientId, PatientEditDTO patient)
        //{
        //    _patientService.UpdatePatientAsync(patientId, patient);
        //    return RedirectToAction(nameof(Index));
        //}

        // GET: PatientController/Delete/5
        public async Task<ActionResult> Remove(Guid id)
        {
            await _patientService.RemovePatientAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<ActionResult> Delete(Guid id)
        {
            await _patientService.DeletePatientAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
