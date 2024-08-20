using Lab_dotNet.entity;
using Microsoft.EntityFrameworkCore;

namespace Lab_dotNet;

public class PhoneCallsDbContext : DbContext
{
    public DbSet<City> Cities { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Conversation> Conversations { get; set; }
    public DbSet<Tariff> Tariffs { get; set; }

    private readonly string _connectionString;

    public PhoneCallsDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }
}
