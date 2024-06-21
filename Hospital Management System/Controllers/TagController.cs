using HospitalManagementSystem.Application.Models;
using HospitalManagementSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        public TagController(ITagService tagService) {
            _tagService = tagService;
        }  
        // GET: TagController
        public async Task<ActionResult> Index()
        {
            var tags = await _tagService.GetTagsAsync();
            return View(tags);
        }

        // GET: TagController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var tag = await _tagService.GetTagAsync(id);
            return View(tag);
        }

        // GET: TagController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TagController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TagDTO tagDTO)
        {
            try
            {
                await _tagService.CreateTag(tagDTO.Name);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: TagController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TagDTO tagDTO)
        {
            await _tagService.EditTag(tagDTO);
            return View("Details", tagDTO);
        }

        // GET: TagController/Delete/5
        
        public async Task<ActionResult> Delete(Guid id)
        {
            await _tagService.RemoveTag(id);
            return RedirectToAction("Index");
        }


    }
}
