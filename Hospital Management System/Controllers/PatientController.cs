﻿using HospitalManagementSystem.Application.Models;
using HospitalManagementSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IUserService _userService;

        public PatientController(IPatientService patientService, IUserService userService)
        {
            _patientService = patientService;
            _userService = userService;
        }


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
        [HttpPost]
        public async Task<ActionResult> Register(UserDTO userDTO)
        {
            if (!await _userService.CheckUnique(userDTO.Username, userDTO.Email))
                return BadRequest("Username and email must be unique");
            try
            {
                await _patientService.RegisterAsync(userDTO);
                return RedirectToAction("Details");
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

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
    }
}
