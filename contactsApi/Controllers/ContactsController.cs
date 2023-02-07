using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using contactsApi.Models;
using contactsApi.Services;

namespace contactsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly ContactContext _context;

        public ContactsController(ContactContext context, ILogger<ContactsController> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // Get all
        // GET: api/Contacts
        [HttpGet(Name = "GetAll")]
        public async Task<ActionResult<List<Contact>>> GetContacts()
        {
            return await _context.Contacts.ToListAsync();
        }

        // CREATE
        // POST: api/Contacts
        // To protect from over-posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost(Name = "Create")]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            try
            {
                if (_context.Contacts == null)
                {
                    return Problem("Entity set 'ContactContext.Contacts'  is null.");
                }

                else if (contact.Name is null || contact.PhoneNumber is null)
                {
                    _logger.LogError("All fields ae required");
                    return BadRequest("All fields ae required");
                }

                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetContact), new { id = contact.Id }, contact);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Something went wrong inside UpdateOwner action: {exception.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new contact record");
            }
        }

        // Read
        // GET: api/Contacts/5
        [HttpGet("{id}", Name = "Read")]
        public async Task<ActionResult<Contact>> GetContact(long id)
        {
            if (_context.Contacts == null)
            {
                return NotFound();
            }
            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        // Update
        // PUT: api/Contacts/5
        // To protect from over-posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}", Name = "Update")]
        public async Task<IActionResult> PutContact(long id, [FromBody] Contact contact)
        {
            try
            {
                if (id != contact.Id)
                {
                    return Content("Employee ID mismatch");
                }

                if (contact is null)
                {
                    _logger.LogError("Contact object sent from client is null.");
                    return BadRequest("Contact object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid contact object sent from client.");
                    return BadRequest("Invalid model object");
                }

                _context.Entry(contact).State = EntityState.Modified;


                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating data");
            }

            return NoContent();
        }


        // DELETE: api/Contacts/5
        [HttpDelete("{id}", Name = "Delete")]
        public async Task<IActionResult> DeleteContact(long id)
        {
            if (_context.Contacts == null)
            {
                return NotFound();
            }
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            var stateBeforeAdd = _context.Entry(contact).State;
            _context.Add(contact);
            var stateAfterAdd = _context.Entry(contact).State;
            _context.SaveChanges();
            var stateAfterSaveChanges = _context.Entry(contact).State;
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return Content("User ${id} has been deleted");
        }

        private bool ContactExists(long id)
        {
            return (_context.Contacts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}


// Alternate way of formatting actions 
// [HttpPost]
// public IActionResult CreateContact(CreateContactRequest request)
// {
//     var contact = new Contact(
//         Guid.NewGuid(),
//         request.Created,
//         request.Name
//     );

// var response = new ContactResponse(
//     contactsApi.Id,
//     contactsApi.name
// );

//     return CreatedAtAction(
//     ActionNameAttribute: nameOf(GetContact),
//     routeValues: new { id= contactsApi.Id},
//     value: response
// );
// }