namespace backend.entities;

public class UserSession
{
    public Guid Id { get; set; }
    
    public User User { get; set; }
    
    public DateTime CreationDate { get; set; }
    public DateTime ExpirationDate { get; set; }
}