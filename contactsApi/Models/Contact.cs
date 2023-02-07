namespace contactsApi.Models;
using System.ComponentModel.DataAnnotations;

public class Contact
{
    public long Id { get; set; }
    public DateTime Created { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
}