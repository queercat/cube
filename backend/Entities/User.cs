using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using backend.entities;

namespace backend.entities;


public class User
{
    public required Guid Id { get; set; }
    
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string EmailAddress { get; set; }

    public required ICollection<Cube> Cubes { get; set; }
}
    