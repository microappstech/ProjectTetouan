using CptVille.Models;
using CptVille.Constant.Exceptions;
using CptVille.Constant;

namespace CptVille.Data.Services
{
    public class BlogService
    {
        private readonly VilleContext _context;
        public BlogService(VilleContext context)
        {
            _context = context;
        }

        public async Task<List<Models.Blog>> GetBlogs()
        {
            var result = _context.Blogs.ToList();
            return await Task.FromResult(result);
            
        }
        public async Task<Blog> GetBlogById(int id)
        {
            var blog = _context.Blogs.FirstOrDefault(b => b.Id == id);
            
            if (blog == null)
            {
                throw new CptVille.Constant.Exceptions.VilleException("غير موجود");
            }
            return await Task.FromResult(blog);
        }
        public async Task<Blog> UpdateBlog(int Id, Blog blog)
        {
            var blogToUpdate = await GetBlogById(Id);
            blogToUpdate.Title = blog.Title;
            blogToUpdate.Description = blog.Description;
            blogToUpdate.CreationDate = blog.CreationDate;
            if (blog.TypeBlog != (int)TypePage.achievements) { blogToUpdate.AchieveSection = 0; }else{ blogToUpdate.AchieveSection = blog.AchieveSection; }
            
            blogToUpdate.TypeBlog = blog.TypeBlog;
            blogToUpdate.Image = blog.Image;
            try
            {
                _context.SaveChanges();
            }
            catch
            {
                throw new VilleException("خطأ في تحديت المقالة");
            }
            return blogToUpdate;
        }
        public async Task<Blog> DeleteBlog(int id)
        {
            var blogToDelete = _context.Blogs.FirstOrDefault(b => b.Id == id);
            _context.Blogs.Remove(blogToDelete);
            try
            {
                _context.SaveChanges();
            }
            catch
            {
                throw new VilleException("حدت خطأ");
            }
            return blogToDelete;

        }
        public async Task<Blog> CreateBlog(Blog blog)
        {
            if (blog.TypeBlog != (int)TypePage.achievements) { blog.AchieveSection = 0; } 
            _context.Blogs.Add(blog);
            try
            {
                _context.SaveChanges();
            }
            catch
            {
                throw new VilleException("حدت خطأ");
            }
            return blog;

        }
    }
}
