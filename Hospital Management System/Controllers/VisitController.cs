using HospitalManagementSystem.Application.Models;
using HospitalManagementSystem.Application.Services;
using HospitalManagementSystem.Domain.Models.People;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class VisitController : Controller
    {
        IVisitService _visitService;
        IPatientService _patientService;
        ITagService _tagService;

        public VisitController(IVisitService visitService, IPatientService patientService, ITagService tagService)
        {
            _visitService = visitService;
            _patientService = patientService;
            _tagService = tagService;
        }

        public async Task<IActionResult> Index()
        {
            var tags = await _tagService.GetTagsAsync();
            var visits = await _visitService.GetCurrentVisitsAsync();
            ViewBag.Tags = tags;

            return View(visits);
        }
        [HttpPost]
        public async Task<IActionResult> Slots(TagDTO tagDTO)
        {
            var visitSlots = await _visitService.GetVisitSlots(tagDTO);
            return View(visitSlots);
        }


        public async Task<IActionResult> Finalize(VisitSlotDTO chosenVisitSlotDTO)
        {
            if (ViewBag.Patients == null && ViewBag.firstname == null && ViewBag.lastname == null && ViewBag.pesel == null)
            {
                var patients = await _patientService.GetPatientsAsync();
                ViewBag.Patients = patients;
            }


            return View(chosenVisitSlotDTO);
        }
        //[HttpPost]
        //public async Task<IActionResult> SearchPatients(VisitSlotDTO chosenVisitSlotDTO, string? firstname, string? lastname, string? pesel)
        //{


        //    var patients = await _patientService.GetPatientsAsync(firstname, lastname, pesel);
        //    ViewBag.Patients = patients;
        //    ViewBag.firstname = firstname;
        //    ViewBag.lastname = lastname;
        //    ViewBag.pesel = pesel;

        //    return View("Finalize", chosenVisitSlotDTO);
        //}
        [HttpPost]
        public async Task<IActionResult> SelectPatient(VisitSlotDTO createFinalVisitDTO)
        {
            var patientDTO = await _patientService.GetPatientAsync(createFinalVisitDTO.PatientId);
            if (patientDTO == null)
            {
                return NotFound("Patient not found");
            }
            
            
            
            return RedirectToAction("FinalizeWithPatient", createFinalVisitDTO);

        }
        public async Task<IActionResult> FinalizeWithPatient(VisitSlotDTO createFinalVisitDTO)
        {

            var visitId = await _visitService.CreateVisit(createFinalVisitDTO);
            return RedirectToAction("Index");
        }

    }
}
