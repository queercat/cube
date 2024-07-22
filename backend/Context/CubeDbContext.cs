using backend.entities;
using Microsoft.EntityFrameworkCore;

namespace backend.context;

public class CubeDbContext : DbContext
{
    public DbSet<Cube> Cubes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<Archetype> Archetypes { get; set; }
    public DbSet<CardInArchetype> CardsInArchetype { get; set; }
    public DbSet<CardInCube> CardsInCube { get; set; }

    public CubeDbContext( DbContextOptions<CubeDbContext> options) : base( options )
    {
        
    }
    
    
}