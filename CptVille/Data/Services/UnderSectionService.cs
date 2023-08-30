using CptVille.Constant.Exceptions;
using CptVille.Models;
using Microsoft.EntityFrameworkCore;

namespace CptVille.Data.Services
{
    public class UnderSectionService
    {
        private readonly VilleContext _context;
        public UnderSectionService(VilleContext context)
        {
            _context = context;
        }

        public async Task<List<Models.UnderSection>> GetUnderSections()
        {
            var result = _context.UnderSections.ToList();
            return await Task.FromResult(result);
        }
        public async Task<UnderSection> GetUnderSectionById(int id)
        {
            var underSection = _context.UnderSections.FirstOrDefault(b => b.Id == id);

            //if (underSection == null)
            //{
            //    throw new CptVille.Constant.Exceptions.VilleException("غير موجود");
            //}
            return await Task.FromResult(underSection);
        }
        public async Task<IEnumerable<UnderSection>> GetUnderSectionByMainId(int id)
        {
            var underSection = await _context.UnderSections.ToListAsync();
            var unders =underSection.Where(b => b.MainSectionId == id);

            if (underSection == null)
            {
                throw new CptVille.Constant.Exceptions.VilleException("غير موجود");
            }
            return await Task.FromResult(unders);
        }
        public async Task<UnderSection> UpdateUnderSection(int Id, UnderSection underSection)
        {
            var underSectionToUpdate = await GetUnderSectionById(Id);
            underSectionToUpdate.Name = underSection.Name;
            try
            {
                _context.SaveChanges();
            }
            catch
            {
                throw new VilleException("خطأ في تحديت ");
            }
            return underSectionToUpdate;
        }
        public async Task<UnderSection> DeleteUnderSection(int id)
        {

            var sectionToDelete = _context.UnderSections.FirstOrDefault(b => b.Id == id);
            _context.UnderSections.Remove(sectionToDelete);
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
        public async Task<UnderSection> CreateUnderSection(UnderSection underSection)
        {
            _context.UnderSections.Add(underSection);
            try
            {
                _context.SaveChanges();
            }
            catch
            {
                throw new VilleException("حدت خطأ");
            }
            return underSection;

        }
    }
}
