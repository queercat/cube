namespace backend.entities;

public class CardInCube
{
    public int Id { get; set; }
    
    public required Cube Cube { get; set; }
    public required Card Card { get; set; }
}