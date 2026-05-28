namespace LibraryManagementAPI.Models.DTOs;

public class UpdateBookDto
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public int Quantity  { get; set; }
}