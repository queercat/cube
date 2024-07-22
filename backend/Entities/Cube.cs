using backend.entities;

namespace backend.entities;

public class Cube
{
    public required int CubeId { get; set; }
    public required string CubeName { get; set; }
    
    public required User User { get; set; }
    
    public ICollection<CardInCube> CardsInCube { get; set; }

}

