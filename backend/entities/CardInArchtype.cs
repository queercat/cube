namespace backend.entities;

// This is a Junction Table in order to facilitate M:M relationship
public class CardInArchetype
{
    public int CardInArchetypeId { get; set; }
    
    public required Archetype Archetype { get; set; }
    public required Card Card { get; set; }
}