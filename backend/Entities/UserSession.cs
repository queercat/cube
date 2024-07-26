namespace backend.entities;

public class UserSession
{
    public Guid Id { get; set; }
    
    public User user { get; set; }
    
    public DateTime ExpirationDate { get; set; }
}