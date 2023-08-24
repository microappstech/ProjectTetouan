using CptVille.Constant;
using CptVille.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

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
            var blogs = _villeContext.Blogs.AsNoTracking().ToList();
            ViewBag.NbrBlogs = blogs.Count();

            var sections = _villeContext.Sections.AsNoTracking().ToList();
            ViewBag.NbrSections = sections.Count();

            var unders = _villeContext.UnderSections.ToList();
            ViewBag.NbrUnderSections = unders.Count();

            var achievement = _villeContext.Achievements.ToList();
            ViewBag.NbrAchievements = achievement.Count();
            base.OnActionExecuted(context);

            var blogss = _villeContext.Blogs.OrderByDescending(b => b.Id).ToList();
            var refrence = _villeContext.Blogs.ToList();
            if (blogss.Count > 4)
            {
                ViewBag.Blogs = blogss.Take(4);
            }
            else
            {
                ViewBag.Blogs = blogss;
            }



            var Paramerters = _villeContext.Parameters.ToList();
            ViewBag.Parameters = Paramerters;


            var AchievementSections = _villeContext.Achievements.ToList();
            foreach (var ach in AchievementSections)
            {
                ach.BlogsFoRachiev = refrence.Where(bl => bl.TypeBlog == (int)TypePage.achievements).ToList();
            }
            ViewBag.BlogAchieve = _villeContext.Blogs.OrderByDescending(b => b.Id).ToList().Where(b => b.TypeBlog == (int)TypePage.achievements).ToList();
            ViewBag.AchievementSections = AchievementSections;


            var pages = _villeContext.DynamicView.Where(t => t.SectionId == 0).OrderByDescending(i => i.Id).ToList();
            foreach (var sect in sections)
            {
                sect.DynamicViews = _villeContext.DynamicView.Where(dv => dv.SectionId == sect.Id).ToList();
            }
            ViewBag.NavPages = pages;
            ViewBag.NavSections = sections;
        }
    }
}
