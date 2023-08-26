
using CptVille.Data;
using CptVille.Data.Services;
using CptVille.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CptVille.Controllers.Admin
{
    [Authorize]
    public class AchieveSectionsController : BaseController
    {
        private readonly AchieveSectionsService _achieveSectionsService;
        public AchieveSectionsController(AchieveSectionsService achieveSectionsService,VilleContext villeContext):base(villeContext)
        {
            this._achieveSectionsService = achieveSectionsService;                            
        }
        public async Task<IActionResult> Index()
        {
            var section =await _achieveSectionsService.GetAchievementSections();
            return View("~/Views/Admin/AchieveSections/AchieveSections.cshtml",section);
        }

        // GET: AchieveSectionsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AchieveSectionsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AchieveSectionsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AchieveSectionsController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var achievesection = await _achieveSectionsService.GetAchieveSectionById(id);
            return View("~/Views/Admin/AchieveSections/Update.cshtml",achievesection);
        }

        // POST: AchieveSectionsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Achievement collection)
        {
            try
            {
                var result = await _achieveSectionsService.UpdateSection(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AchieveSectionsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AchieveSectionsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
