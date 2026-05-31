using System.ComponentModel.DataAnnotations;

namespace LibraryManagementAPI.Models.DTOs;

public class CreateContactDto
{
    public string Name { get; set; }
    
    [RegularExpression(@"^0\d{10}$", ErrorMessage = "Phone number must start with 0 and be 11 digits")]
    public string PhoneNumber { get; set; }
}