using Microsoft.EntityFrameworkCore;

namespace tryiiter.Repository;
using tryiiter.Models;

public class TryiiterContext : DbContext
{
    public TryiiterContext(DbContextOptions<TryiiterContext> options) : base(options)
    {
    }

    public TryiiterContext()
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<PostCategory> PostCategories { get; set; }
    
    public override int SaveChanges()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.Now;

            if (entityEntry.State == EntityState.Added)
            {
                ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.Now;
            }
        }

        return base.SaveChanges();
    }
    
    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<PostCategory>().HasKey(x => new { x.CategoryId, x.PostId });
        mb.Entity<Post>()
            .HasOne(y => y.User)
            .WithMany(y => y.Posts);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        // TODO: configurar variaveis de ambiente
        const string connectionString = "Server=tcp:tryiiter-db.database.windows.net,1433;Initial Catalog=tryiiterDb;Persist Security Info=False;User ID=adminGroup1;Password=P@assw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        optionsBuilder.UseSqlServer(connectionString);
    }
}