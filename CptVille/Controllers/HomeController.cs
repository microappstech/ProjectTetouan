using CptVille.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Localization;
using CptVille.Data;

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