using HospitalManagementSystem.Application.Models;
using HospitalManagementSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        private readonly ITagService _tagService;

        public PatientController(IPatientService patientService, ITagService tagService)
        {
            _patientService = patientService;
            _tagService = tagService;
        }


        public async Task<IEnumerable<PatientDTO>> GetPatientsAsync()
            => await _patientService.GetPatientsAsync();

        [HttpGet]
        // GET: PatientController
        public async Task<IActionResult> Index(IEnumerable<PatientDTO> patients)
        {
            if (patients.Count() == 0)
            {
                patients = await GetPatientsAsync();
            }
            

            return View(patients);
        }

        // GET: PatientController/Details/5
        public async Task<ActionResult> Details(Guid Id)
        {
            var patient = await _patientService.GetPatientDetailsAsync(Id);
            ViewBag.Tags = await _tagService.GetTagsAsync();
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
            var patient = await _patientService.GetPatientAsync(Id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VisitWithSelectedTag(PatientDetailsDTO patient)
        {
            return RedirectToAction("Slots", "Visit", new { patientId = patient.Id ,selectedTag = patient.SelectedTag });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PatientDTO patient)
        {
            await _patientService.UpdatePatientAsync(patient);
            return RedirectToAction(nameof(Index));
        }

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

        [HttpGet]
        public async Task<IActionResult> SearchPatients(string firstName, string lastName, string pesel)
        {
            // Pobierz listę pacjentów na podstawie wyszukiwanych parametrów
            var patients = await _patientService.GetPatientsAsync();

            // Filtruj pacjentów na podstawie wyszukiwanych wartości
            if (!string.IsNullOrEmpty(firstName))
            {
                patients = patients.Where(p => p.FirstName.Contains(firstName, System.StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                patients = patients.Where(p => p.LastName.Contains(lastName, System.StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(pesel))
            {
                patients = patients.Where(p => p.Pesel.Contains(pesel, System.StringComparison.OrdinalIgnoreCase));
            }

            return RedirectToAction("Index", patients);
        }
    }
}
