using Microsoft.EntityFrameworkCore;

namespace contactsApi.Models;

public class ContactContext : DbContext
{
    public ContactContext(DbContextOptions<ContactContext> options) : base(options)
    {

    }

    // Create new entity class
    public DbSet<Contact> Contacts { get; set; } = null!;

    // Added connection string to Program.cs instead. Not needed here
    // Override OnConfiguring and provide connection string to it
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=Contacts; Integrated Security=True;");
    //     base.OnConfiguring(optionsBuilder);
    // }
}