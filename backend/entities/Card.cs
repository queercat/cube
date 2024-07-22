namespace backend.entities;

public class Card
{
    public int CardId { get; set; }
    public required string name { get; set; }
    
    public int OracleId { get; set; } 
}