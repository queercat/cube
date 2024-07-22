using backend.entities;

namespace backend.entities;


public class User
{
    public required int UserId { get; set; }
    public required string name { get; set; }

    public ICollection<Cube> Cubes { get; set; }
}
    