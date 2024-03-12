using Microsoft.EntityFrameworkCore;

namespace DEML20241103.Models
{
    public class DEML20241103Context: DbContext
    {
        public DEML20241103Context(DbContextOptions<DEML20241103Context> options) : base(options)
        {
        }

        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<DetProyecto> DetProyectos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proyecto>()
                .HasMany(v => v.DetProyectos)
                .WithOne(d => d.Proyecto)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
