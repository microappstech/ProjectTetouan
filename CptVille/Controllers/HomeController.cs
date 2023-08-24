using CptVille.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Localization;
using CptVille.Data;
using CptVille.Constant;

namespace CptVille.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VilleContext _villeContext;

        public HomeController(ILogger<HomeController> logger, VilleContext villeContext):base(villeContext)
        {
            _logger = logger;
            this._villeContext = villeContext;
        }

        public IActionResult Index()
        {
            var HeadWordBlog = _villeContext.DynamicView.Where(p => p.TypePage == (int)TypePage.president_word).ToList().FirstOrDefault();
            ViewBag.HeadWordBlog = HeadWordBlog;
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}