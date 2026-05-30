using System.ComponentModel.DataAnnotations;

namespace LibraryManagementAPI.Models.DTOs;

public class CreateBookDto
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Category { get; set; }
    
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
    public double Price { get; set; }
    
    [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative")]
    public int Quantity  { get; set; }
}
