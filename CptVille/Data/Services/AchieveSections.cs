using CptVille.Constant.Exceptions;
using CptVille.Models;

namespace CptVille.Data.Services
{
    public class AchieveSectionsService
    {
        private readonly VilleContext _context;
        public AchieveSectionsService(VilleContext context)
        {
            _context = context;
        }

        public async Task<List<Models.Achievement>> GetAchieveSections()
        {
            var result = _context.Achievements.ToList();
            return await Task.FromResult(result);
        }
        public async Task<List<Models.Achievement>> GetAchievementSections()
        {
            var result = _context.Achievements.ToList();
            return await Task.FromResult(result);
        }
        public async Task<Achievement> GetSectionById(int id)
        {
            var section = _context.Achievements.FirstOrDefault(b => b.Id == id);

            if (section == null)
            {
                throw new CptVille.Constant.Exceptions.VilleException("غير موجود");
            }
            return await Task.FromResult(section);
        }
        public async Task<Achievement> GetAchieveSectionById(int id)
        {
            var section = _context.Achievements.Find(id);
            if (section == null)
            {
                throw new CptVille.Constant.Exceptions.VilleException("غير موجود");
            }
            return await Task.FromResult(section);
        }
        public async Task<Achievement> UpdateSection(int Id, Achievement section)
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
        public async Task<Achievement> DeleteSection(int id)
        {

            var achievementToDelete = _context.Achievements.FirstOrDefault(b => b.Id == id);
            _context.Achievements.Remove(achievementToDelete);
            try
            {
                _context.SaveChanges();
            }
            catch
            {
                throw new VilleException("حدت خطأ");
            }
            return achievementToDelete;

        }
        public async Task<Achievement> CreateSection(Achievement achievement)
        {
            _context.Achievements.Add(achievement);
            try
            {
                _context.SaveChanges();
            }
            catch
            {
                throw new VilleException("حدت خطأ");
            }
            return achievement;

        }
    }
}
