using System.ComponentModel.DataAnnotations;

namespace contactsApi;

public class ContactDTO
{
    public long Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; set; }
    public int PhoneNumber { get; set; }
    public string? Secret { get; set; }
    public bool IsComplete { get; set; }
}