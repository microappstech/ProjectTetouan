using Microsoft.EntityFrameworkCore;
using CptVille.Models;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using CptVille.Constant;

namespace CptVille.Data.Services
{
    public class ServiceDynamicView
    {
        private readonly VilleContext _context;
        public ServiceDynamicView(VilleContext villeContext) 
        {
            this._context = villeContext;
        }
        public async Task<List<Models.DynamicView>> GetViews()
        {
            var result = _context.DynamicView.ToList();
            return await Task.FromResult(result);
        }
        public async Task<DynamicView> EditView(int id , DynamicView view, IFormFile Image)
        {
            if (Image != null && Image.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    Image.CopyTo(memoryStream);
                    var base64String = Convert.ToBase64String(memoryStream.ToArray());
                    view.ImageCover = "data:image/png;base64," + base64String.ToString();
                }
            }
            var result = await GetViewById(id);
            if(view.TypePage == (int)TypePage.economic_field || view.TypePage == (int)TypePage.infrastructure || view.TypePage == (int)TypePage.normalenvirenemen ||
                view.TypePage == (int)TypePage.demographicdatat || view.TypePage == (int)TypePage.regionalidentification)
            {
                result.SectionId = _context.Sections.ToList().FirstOrDefault().Id;
            }
            else if (view.TypePage == (int)TypePage.council_office || view.TypePage == (int)TypePage.president_word ||
                view.TypePage == (int)TypePage.board_committees || view.TypePage == (int)TypePage.council_activite )
            {
                result.SectionId = _context.Sections.ToList().LastOrDefault().Id;
            }
            else
            {
                result.SectionId = 0;
            }
            result.ViewName = view.ViewName;
            result.ViewDesign = view.ViewDesign;
            result.TypePage = view.TypePage;
            result.ImageCover = view.ImageCover;
            _context.SaveChanges();
            return await Task.FromResult(result);
        }
        public async Task<DynamicView> GetViewById(int id)
        {
            var result = _context.DynamicView.Find(id);
            return await Task.FromResult(result);
        }
        public async Task<DynamicView> GetViewByType(int id)
        {
            var result = _context.DynamicView.Where(dv=>dv.TypePage==id).FirstOrDefault();
            return await Task.FromResult(result);
        }
        public async Task<DynamicView> DeleteView(int id)
        {
            var result = await GetViewById(id);
            _context.DynamicView.Remove(result);
            _context.SaveChanges();
            return await Task.FromResult(result);
        }
        public async Task<DynamicView> CreateView(DynamicView dynamic, IFormFile Image)
        {
            if(Image != null && Image.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    Image.CopyTo(memoryStream);
                    var base64String = Convert.ToBase64String(memoryStream.ToArray());
                    dynamic.ImageCover = "data:image/png;base64," + base64String.ToString();
                }
            }
            _context.DynamicView.Add(dynamic);
            _context.SaveChanges();
            return await Task.FromResult(dynamic);
        }

        
        
    }
}
