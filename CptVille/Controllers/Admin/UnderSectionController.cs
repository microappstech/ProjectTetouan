using CptVille.Data;
using CptVille.Data.Services;
using CptVille.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CptVille.Controllers.Admin
{
    [Authorize]
    public class UnderSectionController : BaseAdminController
    {
        private readonly UnderSectionService _underSectionService;
        private readonly SectionService _sectionService;
        public UnderSectionController(UnderSectionService underSectionService, SectionService sectionService, VilleContext villeContext) : base(villeContext)
        {
            _underSectionService = underSectionService;
            _sectionService = sectionService;
        }
        // GET: UnderSectionController
        public async Task<IActionResult> Index()
        {
            var unders = await _underSectionService.GetUnderSections();
            foreach(var item in unders)
            {
                item.Section = await _sectionService.GetSectionById((int)item.MainSectionId);
            }
            return View("~/Views/Admin/UnderSection/UnderSections.cshtml",unders);
        }

        // GET: UnderSectionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UnderSectionController/Create
        public async Task<IActionResult> Create()
        {
            var sections = await _sectionService.GetSections();
            ViewBag.Sections = sections;
            return View("~/Views/Admin/UnderSection/Create.cshtml");
        }

        // POST: UnderSectionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UnderSection collection)
        {
            try
            {
                var result = await _underSectionService.CreateUnderSection(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UnderSectionController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var underSection = await _underSectionService.GetUnderSectionById(id);
            underSection.Section = await _sectionService.GetSectionById((int)underSection.MainSectionId);
            var sections = await _sectionService.GetSections();
            ViewBag.Sections = sections;
            return View("~/Views/Admin/UnderSection/Update.cshtml",underSection);
        }

        // POST: UnderSectionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UnderSection collection)
        {
            try
            {
                var re = await _underSectionService.UpdateUnderSection(id , collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UnderSectionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UnderSectionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var result = await _underSectionService.DeleteUnderSection(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
