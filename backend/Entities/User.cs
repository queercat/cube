using System.ComponentModel.DataAnnotations;
using backend.entities;

namespace backend.entities;


public class User
{
    public required int UserId { get; set; }
    public required string Name { get; set; }

    public required ICollection<Cube> Cubes { get; set; }
}
    