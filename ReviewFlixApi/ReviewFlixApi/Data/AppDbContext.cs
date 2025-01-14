namespace ReviewFlixApi.Data;

using Microsoft.EntityFrameworkCore;
using ReviewFlixApi.Models;
public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Film> Films { get; set; }
    public DbSet<Finance> Finances { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Casting> Castings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Finance>()
            .HasOne<Film>()
            .WithOne()
            .HasForeignKey<Finance>(f => f.FilmId)
            .OnDelete(DeleteBehavior.Cascade);

        
        modelBuilder.Entity<Review>()
            .HasOne<Film>()
            .WithMany()
            .HasForeignKey(r => r.FilmId)
            .OnDelete(DeleteBehavior.Cascade);

        
        modelBuilder.Entity<Casting>()
            .HasKey(c => new { c.FilmId, c.ActorId }); 

        modelBuilder.Entity<Casting>()
            .HasOne<Film>()
            .WithMany()
            .HasForeignKey(c => c.FilmId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Casting>()
            .HasOne<Actor>()
            .WithMany()
            .HasForeignKey(c => c.ActorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
