namespace backend.entities;

public class CardInCube
{
    public int CardInCubeId { get; set; }
    
    public Cube Cube { get; set; }
    public Card Card { get; set; }
}