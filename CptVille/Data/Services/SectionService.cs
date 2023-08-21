using CptVille.Constant.Exceptions;
using CptVille.Models;

namespace CptVille.Data.Services
{
    public class SectionService
    {
        private readonly VilleContext _context;
        public SectionService(VilleContext context)
        {
            _context = context;
        }

        public async Task<List<Models.Section>> GetSections()
        {
            var result = _context.Sections.ToList();
            return await Task.FromResult(result);
        }
        public async Task<Section> GetSectionById(int id)
        {
            var section = _context.Sections.FirstOrDefault(b => b.Id == id);

            if (section == null)
            {
                throw new CptVille.Constant.Exceptions.VilleException("غير موجود");
            }
            return await Task.FromResult(section);
        }
        public async Task<Section> GetSectionByUnderId(int id)
        {
            var section = _context.Sections.FirstOrDefault();
            if (section == null)
            {
                throw new CptVille.Constant.Exceptions.VilleException("غير موجود");
            }
            return await Task.FromResult(section);
        }
        public async Task<Section> UpdateSection(int Id, Section section)
        {
            var sectionToUpdate = await GetSectionById(Id);
            sectionToUpdate.Name = section.Name;
            try
            {
                _context.SaveChanges();
            }
            catch
            {
                throw new VilleException("خطأ في تحديت المقالة");
            }
            return sectionToUpdate;
        }
        public async Task<Section> DeleteSection(int id)
        {

            var sectionToDelete = _context.Sections.FirstOrDefault(b => b.Id == id);
            _context.Sections.Remove(sectionToDelete);
            try
            {
                _context.SaveChanges();
            }
            catch
            {
                throw new VilleException("حدت خطأ");
            }
            return sectionToDelete;

        }
        public async Task<Section> CreateSection(Section section)
        {
            _context.Sections.Add(section);
            try
            {
                _context.SaveChanges();
            }
            catch
            {
                throw new VilleException("حدت خطأ");
            }
            return section;

        }
    }
}
