namespace backend.entities;

// This is a Junction Table in order to facilitate M:M relationship
public class CardInArchetype
{
    public int CardInArchetypeId { get; set; }
    
    public required Archtype Archtype { get; set; }
    public required Card Card { get; set; }
}