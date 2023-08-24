using CptVille.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Localization;
using CptVille.Data;
using CptVille.Constant;
using Microsoft.EntityFrameworkCore;

namespace CptVille.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, VilleContext villeContext):base(villeContext)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Achievement()
        {
            var AchievemntBlog = _villeContext.Blogs.Where(b => b.TypeBlog == (int)TypePage.achievements).AsNoTracking().ToList();
            return View("~/Views/Home/Achievement.cshtml",AchievemntBlog);
        }
        public IActionResult AdsBlog()
        {
            var AdsBlog = _villeContext.Blogs.Where(b => b.TypeBlog == (int)TypePage.ads_blogs).AsNoTracking().ToList();
            return View("~/Views/Home/AdsBlog.cshtml", AdsBlog);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}