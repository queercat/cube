namespace backend.entities;

public class Archtype
{
    public int ArchetypeId { get; set; }
    
    public List<CardInArchetype> CardsInArchetype { get; set; }
    
}