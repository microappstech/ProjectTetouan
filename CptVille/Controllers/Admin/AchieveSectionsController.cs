using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CptVille.Controllers.Admin
{
    public class AchieveSectionsController : Controller
    {
        // GET: AchieveSectionsController
        public ActionResult Index()
        {
            return View("~/Views/Admin/AchieveSections/AchieveSections.cshtml");
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AchieveSectionsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
