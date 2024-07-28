namespace backend.entities;

public class UserAuth // Still Work in progress
{
    public int UserAuthId { get; set; }
    public required string Password { get; set; } // Not sure the best way to store this information
    
    public required User UserId { get; set; }
    
}