using CptVille.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Localization;
using CptVille.Data;
using CptVille.Data.Services;
using System.IO;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;

namespace CptVille.Controllers.Admin
{
    public class AdminController:BaseAdminController
    {
        private readonly ILogger<AdminController> _logger;
        private readonly BlogService _blogService;
        private readonly SectionService _sectionService;
        private readonly UnderSectionService _underSectionService;
        private readonly ParamaeterSevice _parameterSevice;
        public AdminController(ParamaeterSevice paramaeterSevice, BlogService blogService, SectionService sectionService, UnderSectionService underSectionService , ILogger<AdminController> logger,VilleContext villeContext):base(villeContext)
        {
            this._logger = logger;
            _blogService = blogService;
            _sectionService = sectionService;
            _underSectionService = underSectionService;
            this._parameterSevice = paramaeterSevice;
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
            var underss = await GetUnders(0);
            ViewBag.sections = sections;
            ViewBag.unders = new List<UnderSection>() { };

            return View("~/Views/Admin/Blogs/Create.cshtml");
            //return View("~/Views/Admin/Blogs/Test.cshtml");
        }
        public async Task<IActionResult> GetUnders(int id)
        {
            if (id == 3)
            {
                var unders = await _sectionService.GetAchievementSections();
                return Json(unders);
            }
            else
            {
                var unders = await _underSectionService.GetUnderSectionByMainId(id);
                return Json(unders);
            }
        }


        // POST: BlogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blog collection, IFormFile Image)
        {
            try
            {
                if (Image != null && Image.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        Image.CopyTo(memoryStream);
                        var base64String = Convert.ToBase64String(memoryStream.ToArray());
                        collection.Image = "data:image/png;base64," + base64String.ToString();
                      }
                }
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
        public async Task<IActionResult> Edit(int id, Blog collection, IFormFile Image)
        {
            try
            {
                if (Image != null && Image.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        Image.CopyTo(memoryStream);
                        var base64String = Convert.ToBase64String(memoryStream.ToArray());
                        collection.Image = "data:image/png;base64," + base64String.ToString();
                    }
                }
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
            var MainSections = await _sectionService.GetSections();
            foreach (var sec in MainSections)
            {
                var r =await _underSectionService.GetUnderSectionByMainId(sec.Id) ;
                sec.UnderSections = r.ToList();

                //sec.UnderSections = _villeContext.UnderSections.Where(s => s.MainSectionId == sec.Id).ToList();
            }
            ViewBag.MainSections = MainSections;
            var UnderSections = await _underSectionService.GetUnderSections();
            ViewBag.UnderSections = UnderSections;
            var blog = await _blogService.GetBlogById(id);
            blog.Section = await _sectionService.GetSectionById((int)blog.SectionId);
            if(blog.UnderSectionId != null)
            {
                blog.UnderSection = await _underSectionService.GetUnderSectionById((int)blog.UnderSectionId);
            }
            else
            {
                
            }

            var Paramerters = await _parameterSevice.GetAllParametes();
            ViewBag.Parameters = Paramerters;
            return View("~/Views/Home/BlogDetails.cshtml", blog);
        }
        public async void UploadIcon(IBrowserFile icon)
        {
            MemoryStream ms = new MemoryStream();
            await icon.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024).CopyToAsync(ms);
            var bytes = ms.ToArray();
            string base64ImageRepresentation = Convert.ToBase64String(bytes);
            //book.Icon = "data:image/png;base64," + base64ImageRepresentation;
        }
    }
}
