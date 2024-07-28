namespace backend.entities;

public class Card
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required int OracleId { get; set; }
    public ICollection<Cube> Cubes { get; set; }
}