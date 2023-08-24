using Microsoft.EntityFrameworkCore;
using CptVille.Models;
namespace CptVille.Data
{
    public class VilleContext : DbContext
    {
        public VilleContext(DbContextOptions<VilleContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Section>()
                .HasMany(s => s.UnderSections)
                .WithOne(u => u.Section)
                .HasForeignKey(s => s.MainSectionId)
                .HasPrincipalKey(u => u.Id);
                
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<UnderSection> UnderSections { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<AchievementSections> AchievementSections { get; set; }
        public DbSet<Parameters> Parameters { get; set; }
        public DbSet<DynamicView> DynamicView { get; set; }

    }
}
