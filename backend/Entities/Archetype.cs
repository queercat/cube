namespace backend.entities;

public class Archetype
{
    public required int ArchetypeId { get; set; }
    public required List<CardInArchetype> CardsInArchetype { get; set; }
    
}