using backend.entities;
using Microsoft.EntityFrameworkCore;

namespace backend.context;

public class CubeDbContext(DbContextOptions<CubeDbContext> options) : DbContext(options)
{
    public required DbSet<Cube> Cubes { get; set; }
    public required DbSet<User> Users { get; set; }
    public required DbSet<UserSession> UserSessions { get; set; }
    public required DbSet<Card> Cards { get; set; }
}