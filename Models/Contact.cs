namespace LibraryManagementAPI.Models;

public class Contact
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public NetworkProvider NetworkProvider { get; set; }
    
    public DateTime CreatedAt { get; set; } =  DateTime.UtcNow;
}