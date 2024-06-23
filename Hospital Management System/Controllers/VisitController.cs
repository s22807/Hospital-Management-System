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
        public async Task<IActionResult> Slots(Guid Id, Guid selectedTag)
        {
            if(selectedTag == Guid.Empty)
            {
                throw new Exception("Tag not selected");
            }
            var tagDTO = new TagDTO() { Id = selectedTag };
            var visitSlots = await _visitService.GetVisitSlots(tagDTO, Id);
            return View(visitSlots);
        }


        public async Task<IActionResult> Finalize(VisitSlotDTO chosenVisitSlotDTO)
        {

            var visitId = await _visitService.CreateVisit(chosenVisitSlotDTO);
            

            return Redirect($"/Patient/Details/{chosenVisitSlotDTO.PatientId}");
        }
        public async Task<IActionResult> Cancel(Guid visitId)
        {
            await _visitService.CancelVisit(visitId);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Done(Guid visitId)
        {
            await _visitService.registerDoneVisit(visitId);
            return RedirectToAction("Index");
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


    }
}
