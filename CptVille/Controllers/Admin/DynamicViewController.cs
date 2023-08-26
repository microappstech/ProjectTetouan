using CptVille.Constant;
using CptVille.Data;
using CptVille.Data.Services;
using CptVille.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CptVille.Controllers.Admin
{
    [Authorize]
    public class DynamicViewController : BaseController
    {
        private readonly ServiceDynamicView _serviceDynamicView;
        public DynamicViewController(VilleContext villeContext, ServiceDynamicView serviceDynamicView) : base(villeContext)
        {
            _serviceDynamicView = serviceDynamicView;
        }


        public async Task<IActionResult> Index()
        {
            var Pages =await _serviceDynamicView.GetViews();
            return View("~/Views/Admin/DynamicView/GetViews.cshtml",Pages);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var view =await _serviceDynamicView.GetViewById(id);
            if ( view.TypePage == (int)TypePage.achievements) 
            {
                return View("~/Views/Home/Achievement.cshtml");
            }
            if (view.TypePage == (int)TypePage.ads_blogs )
            {
                return View("~/Views/Home/AdsBlog.cshtml");
            }
            if(view.TypePage == (int)TypePage.council_activite)
            {
                var BlogActivites = _villeContext.Blogs.Where(b=>b.TypeBlog == (int)TypePage.council_activite).ToList();
                return View("~/Views/Home/CouncilActivite.cshtml", BlogActivites);
            }
                
            return View("~/Views/Home/DynamicView.cshtml", view);
        }

        // GET: DynamicViewController/Create
        public ActionResult Create()
        {
            var view = new DynamicView();
            return View("~/Views/Admin/DynamicView/Create.cshtml",view);
        }

        // POST: DynamicViewController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DynamicView collection,IFormFile ImageCover)
        {
            try
            {
                try
                {
                    var result   = await _serviceDynamicView.CreateView(collection, ImageCover);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    throw new Exception("");

                }
            }
            catch
            {
                return View();
            }
        }

        // GET: DynamicViewController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var view = await _serviceDynamicView.GetViewById(id);
            return View("~/Views/Admin/DynamicView/Update.cshtml", view);
        }

        // POST: DynamicViewController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DynamicView collection, IFormFile ImageCover)
        {
            try
            {
                var result =await  _serviceDynamicView.EditView(id,collection, ImageCover);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DynamicViewController/Delete/5
       

        // POST: DynamicViewController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                //var res = await _serviceDynamicView.GetViewById(id);
                var result = await _serviceDynamicView.DeleteView(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
