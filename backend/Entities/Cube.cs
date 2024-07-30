using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.entities;

namespace backend.entities;

public class Cube
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key, Column(Order = 0)]
    public int Id { get; set; }
    public required string CubeName { get; set; }
    public required User User { get; set; }
    
    public ICollection<Card> Cards { get; set; }

}

