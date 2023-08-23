using CptVille.Data;
using CptVille.Data.Services;
using CptVille.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CptVille.Controllers
{
    public class BaseController : Controller
    {

        private readonly VilleContext _villeContext;
        public BaseController(VilleContext villeContext)
        {
            _villeContext = villeContext;
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var MainSections = _villeContext.Sections.ToList();
            foreach(var sec in MainSections)
            {
                sec.UnderSections = _villeContext.UnderSections.Where(s=>s.MainSectionId == sec.Id).ToList();
            }
            ViewBag.MainSections = MainSections;
            var UnderSections = _villeContext.UnderSections.ToList();
            ViewBag.UnderSections = UnderSections;

            var Blogs = _villeContext.Blogs.OrderByDescending(b=>b.Id).ToList().Where(b=>b.SectionId!=3).ToList();
            if (Blogs.Count > 4)
            {
                ViewBag.Blogs = Blogs.Take(4);
            }
            else
            {
                ViewBag.Blogs = Blogs;
            }

            var Paramerters = _villeContext.Parameters.ToList();
            ViewBag.Parameters = Paramerters;


            var AchievementSections = _villeContext.Achievements.ToList();
            foreach(var ach in AchievementSections)
            {
                ach.BlogsFoRachiev = Blogs.Where(b=>b.UnderSectionId == ach.Id).ToList();
            }
            ViewBag.BlogAchieve = _villeContext.Blogs.OrderByDescending(b => b.Id).ToList().Where(b => b.SectionId == 3).ToList();
            ViewBag.AchievementSections = AchievementSections;


            base.OnActionExecuted(context);
        }

    }
}
