using Microsoft.EntityFrameworkCore;

namespace tryiiter.Repository;

public class TryiiterContext : DbContext
{
    public TryiiterContext(DbContextOptions<TryiiterContext> options) : base(options)
    {
    }

    public TryiiterContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        // TODO: configurar variaveis de ambiente
        const string connectionString = "Server=127.0.0.1;Database=tryiiter_db;User=SA;Password=Password12!;TrustServerCertificate=true";
        optionsBuilder.UseSqlServer(connectionString);

    }
}