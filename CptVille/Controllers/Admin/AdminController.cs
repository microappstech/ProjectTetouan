using CptVille.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Localization;
using CptVille.Data;
using CptVille.Data.Services;
using Microsoft.VisualBasic;

namespace CptVille.Controllers.Admin
{
    public class AdminController:Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly BlogService _blogService;
        private readonly SectionService _sectionService;
        private readonly UnderSectionService _underSectionService;
        public AdminController(BlogService blogService, SectionService sectionService, UnderSectionService underSectionService , ILogger<AdminController> logger)
        {
            this._logger = logger;
            _blogService = blogService;
            _sectionService = sectionService;
            _underSectionService = underSectionService;
        }

        public async Task<IActionResult> Index()
        {
            var Blogs =await _blogService.GetBlogs();
            return View("~/Views/Admin/Blogs/Index.cshtml",Blogs);
        }

        // GET: BlogController/Create
        public async Task<IActionResult> Create()
        {
            var sections = await _sectionService.GetSections();
            var unders = await GetUnders(0);
            ViewBag.unders = new List<UnderSection>();
            ViewBag.sections = sections;

            return View("~/Views/Admin/Blogs/Create.cshtml");
            //return View("~/Views/Admin/Blogs/Test.cshtml");
        }
        public async Task<IActionResult> GetUnders(int id)
        {
            var unders = await _underSectionService.GetUnderSectionByMainId(id);
            return Json(unders);
        }


        // POST: BlogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blog collection)
        {
            try
            {
                var res = await _blogService.CreateBlog(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var blog = await _blogService.GetBlogById(id);
            ViewBag.unders = new List<UnderSection>();
            if(blog.UnderSectionId == null)
            {
                blog.UnderSectionId = 0;
            }
            else
            {
                blog.UnderSection = await _underSectionService.GetUnderSectionById((int)blog.UnderSectionId);
                blog.SectionId = blog.UnderSection.MainSectionId;
                var unders = await _underSectionService.GetUnderSectionByMainId((int)blog.SectionId);
                ViewBag.unders = unders; 

            }
            var sections = await _sectionService.GetSections();
            ViewBag.sections = sections;
            if (sections.Count <= 0)
            {
                ViewBag.sections = new List<Section>();
            }
            return View("~/Views/Admin/Blogs/Update.cshtml",blog);
        }

        // POST: BlogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Blog collection)
        {
            try
            {
                var res = await _blogService.UpdateBlog(id,collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BlogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var result = await _blogService.DeleteBlog(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Details(int id)
        {
            var blog = await _blogService.GetBlogById(id);
            blog.Section = await _sectionService.GetSectionById((int)blog.SectionId);
            if(blog.UnderSectionId != null)
            {
                blog.UnderSection = await _underSectionService.GetUnderSectionById((int)blog.UnderSectionId);
            }
            else
            {
                
            }
            return View("~/Views/Home/BlogDetails.cshtml", blog);
        }
    }
}
