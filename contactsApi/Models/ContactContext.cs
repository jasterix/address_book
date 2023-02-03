using Microsoft.EntityFrameworkCore;

namespace contactsApi.Models;

public class ContactContext : DbContext
{
    public ContactContext(DbContextOptions<ContactContext> options) : base(options)
    {

    }
    public DbSet<Contact> Contacts { get; set; } = null!;
}