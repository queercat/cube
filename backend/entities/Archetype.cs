namespace backend.entities;

public class Archetype
{
    public int ArchetypeId { get; set; }
    
    public List<CardInArchetype> CardsInArchetype { get; set; }
    
}