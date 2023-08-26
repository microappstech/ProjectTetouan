using CptVille.Constant;
using CptVille.Data;
using CptVille.Data.Services;
using CptVille.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CptVille.Controllers
{
    public class BaseController : Controller
    {

        protected readonly VilleContext _villeContext;
        public BaseController(VilleContext villeContext)
        {
            _villeContext = villeContext;
        }
        protected VilleContext GetVilleContext()
        {
            return _villeContext;
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var blogs = _villeContext.Blogs.Where(b=>b.TypeBlog!=(int)TypePage.achievements).OrderByDescending(b => b.Id).ToList();
            var refrence = _villeContext.Blogs.ToList();
            if (blogs.Count > 4)
            {
                ViewBag.Blogs = blogs.Take(4);
            }
            else
            {
                ViewBag.Blogs = blogs;
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


            var pages = _villeContext.DynamicView.Where(t=>t.SectionId==0).OrderByDescending(i=>i.Id).ToList();
            var sections = _villeContext.Sections.ToList();
            foreach(var sect in sections)
            {
                sect.DynamicViews = _villeContext.DynamicView.Where(dv => dv.SectionId == sect.Id).ToList();
            }
            ViewBag.NavPages = pages;
            ViewBag.NavSections = sections;

            var HeadWordBlog = _villeContext.DynamicView.Where(p => p.TypePage == (int)TypePage.president_word).ToList().FirstOrDefault();
            ViewBag.HeadWordBlog = HeadWordBlog;
            base.OnActionExecuted(context);
        }

    }
}
