using backend.entities;

namespace backend.entities;

public class Cube
{
    public required int Id { get; set; }
    public required string CubeName { get; set; }
    public required User User { get; set; }
    
    public required ICollection<Card> Cards { get; set; }

}

