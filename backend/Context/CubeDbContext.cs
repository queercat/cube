using backend.entities;
using backend.entities.SeedData;
using Microsoft.EntityFrameworkCore;

namespace backend.context;

public class CubeDbContext(DbContextOptions<CubeDbContext> options) : DbContext(options)
{
    private readonly ISeeder<Card> _cardSeeder = new CardSeeder();
    
    public required DbSet<Cube> Cubes { get; set; }
    public required DbSet<User> Users { get; set; }
    public required DbSet<UserSession> UserSessions { get; set; }
    public required DbSet<Card> Cards { get; set; }
    public required DbSet<Nonce> Nonces { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Card>().HasData(_cardSeeder.GenerateSeedData());
    }
}