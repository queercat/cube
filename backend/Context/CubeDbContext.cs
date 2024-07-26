using backend.entities;
using Microsoft.EntityFrameworkCore;

namespace backend.context;

public class CubeDbContext(DbContextOptions<CubeDbContext> options) : DbContext(options)
{
    
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserSession> UserSessions { get; set; }
    
    public virtual DbSet<Cube> Cubes { get; set; }
    public virtual DbSet<Card> Cards { get; set; }
    public virtual DbSet<Archetype> Archetypes { get; set; }
    
    public virtual DbSet<CardInArchetype> CardsInArchetype { get; set; }
    public virtual DbSet<CardInCube> CardsInCube { get; set; }
    
    
}