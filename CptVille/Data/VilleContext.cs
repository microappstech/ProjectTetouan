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
            modelBuilder.Entity<Blog>()
                .HasOne(b => b.UnderSection)
                .WithMany(b => b.Blogs)
                .HasForeignKey(b => b.UnderSectionId)
                .HasPrincipalKey(c => c.Id);

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

    }
}
