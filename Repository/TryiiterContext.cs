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
    
    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<PostCategory>().HasKey(x => new { x.CategoryId, x.PostId });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        // TODO: configurar variaveis de ambiente
        const string connectionString = "Server=127.0.0.1;Database=tryiiter_db;User=SA;Password=Password12!;TrustServerCertificate=true";
        optionsBuilder.UseSqlServer(connectionString);
    }
}