using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.entities;

public class Card
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key, Column(Order = 0)]
    public  int Id { get; set; }
    public required string Name { get; set; }
    public required int OracleId { get; set; }
    public ICollection<Cube> Cubes { get; set; }
}