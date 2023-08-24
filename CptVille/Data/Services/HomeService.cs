using CptVille.Models;

namespace CptVille.Data.Services
{
    public class HomeService
    {
        private readonly VilleContext _context;
        public HomeService(VilleContext context)
        {
            _context = context;
        }  
    }
}
