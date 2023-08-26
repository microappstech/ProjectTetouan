using CptVille.Data;
using CptVille.Data.Services;
using CptVille.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CptVille.Controllers.Admin
{
    [Authorize]
    public class SectionController : BaseAdminController
    {
        private readonly SectionService _sectionService;    
        public SectionController(SectionService sectionService, VilleContext villeContext) : base(villeContext)
        {
            this._sectionService = sectionService;
        }
        public async Task<IActionResult> Index()
        {
            var Sections = await _sectionService.GetSections();
            return View("~/Views/Admin/Sections/Sections.cshtml",Sections);
        }

        // GET: SectionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SectionController/Create
        public IActionResult Create()
        {
            Section section = new Section();  
            return View("~/Views/Admin/Sections/Create.cshtml", section);
        }

        // POST: SectionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Section collection)
        {
            try
            {
                var result = await _sectionService.CreateSection(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SectionController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var section = await _sectionService.GetSectionById(id);
            return View("~/Views/Admin/Sections/Update.cshtml",section);
        }

        // POST: SectionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Section collection)
        {
            try
            {
                var restul = await _sectionService.UpdateSection(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SectionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SectionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var result = await _sectionService.DeleteSection(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
