using CptVille.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CptVille.Data.Services;
using CptVille.Models;
using CptVille.Constant;
using System.Reflection.Metadata;

namespace CptVille.Controllers.Admin
{
    public class ParameterController : BaseAdminController
    {
        private readonly ParamaeterSevice _paramaeterSevice;
        public ParameterController(ParamaeterSevice paramaeterSevice, VilleContext villeContext) : base(villeContext)
        {
            this._paramaeterSevice = paramaeterSevice;
        }
        // GET: ParameterController
        public async Task<IActionResult> Index()
        {
            var paramss = await _paramaeterSevice.GetAllParametes();
            return View("~/Views/Admin/Prametters/Parametters.cshtml",paramss);
        }

        // GET: ParameterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ParameterController/Create
        public ActionResult Create()
        {
            return View("~/Views/Admin/Prametters/Create.cshtml");
        }

        // POST: ParameterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Parameters collection)
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

        // GET: ParameterController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var param = await _paramaeterSevice.GetParameterById(id);
            return View("~/Views/Admin/Prametters/Update.cshtml",param);
        }

        // POST: ParameterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Parameters collection,IFormFile ImageValue)
        {
            try
            {
               if ((int)collection.TypePara == (int)TypeParams.image && ImageValue !=null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        ImageValue.CopyTo(memoryStream);
                        var base64String = Convert.ToBase64String(memoryStream.ToArray());
                        collection.Value = "data:image/png;base64," + base64String.ToString();
                    }
                }
                var resultUpdate = await _paramaeterSevice.UpdateParameter(id,collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ParameterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ParameterController/Delete/5
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
