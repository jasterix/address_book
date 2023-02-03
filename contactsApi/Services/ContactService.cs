using contactsApi.Models;

namespace contactsApi.Services;

public static class ContactService
{
    static List<Contact> Contacts { get; }
    static int nextId = 2;
    static ContactService()
    {
        Contacts = new List<Contact>
        {
            new Contact { Id = 0, Created =  DateTime.Now, Name = "Frodo Baggins", PhoneNumber = "555-555-5555"},
            new Contact { Id = 1, Created = DateTime.Now, Name = "Elu Thingol", PhoneNumber = "555-556-5656"}
        };
    }

    public static List<Contact> GetAll() => Contacts;

    public static Contact? Get(int id) => Contacts.FirstOrDefault(p => p.Id == id);

    public static void Add(Contact contact)
    {
        contact.Id = nextId++;
        Contacts.Add(contact);
    }

    public static void Delete(int id)
    {
        var contact = Get(id);
        if (contact is null)
            return;

        Contacts.Remove(contact);
    }

    public static void Update(Contact contact)
    {
        var index = Contacts.FindIndex(c => c.Id == contact.Id);
        if (index == -1)
            return;

        Contacts[index] = contact;
    }
}