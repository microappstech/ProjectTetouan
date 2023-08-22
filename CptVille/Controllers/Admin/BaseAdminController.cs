using CptVille.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CptVille.Controllers.Admin
{
    public class BaseAdminController : Controller
    {
        private readonly VilleContext _villeContext;
        public BaseAdminController(VilleContext villeContext)
        {
            _villeContext = villeContext;
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var blogs = _villeContext.Blogs.ToList();
            ViewBag.NbrBlogs = blogs.Count();

            var sections = _villeContext.Sections.ToList();
            ViewBag.NbrSections = sections.Count();

            var unders = _villeContext.UnderSections.ToList();
            ViewBag.NbrUnderSections = unders.Count();

            var achievement = _villeContext.Achievements.ToList();
            ViewBag.NbrAchievements = achievement.Count();
            base.OnActionExecuted(context);
        }
    }
}
