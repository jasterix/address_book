namespace contactsApi.Models;

public class Contact
{
    public long Id { get; set; }
    public DateTime Created { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    // public string? Secret { get; set; }

}