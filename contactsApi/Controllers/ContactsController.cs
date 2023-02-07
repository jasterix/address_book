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
                    _logger.LogError("Invalid contact object sent from client.");
                    return Problem("Contact object is null.");
                }
                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetContact), new { id = contact.Id }, contact);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Something went wrong inside UpdateOwner action: {exception.Message}");
                return NotFound();
            }
        }

        // Read
        // GET: api/Contacts/5
        [HttpGet("{id}", Name = "Read")]
        public async Task<ActionResult<Contact>> GetContact(long id)
        {
            try
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
            catch (Exception exception)
            {
                _logger.LogError($"Something went wrong inside UpdateOwner action: {exception.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error finding contact.");
            }
        }

        // Update
        // PUT: api/Contacts/5
        // To protect from over-posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}", Name = "Update")]
        public async Task<IActionResult> PutContact(long id, [FromBody] Contact update)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if (id != contact.Id)
            {
                _logger.LogError("Id not found.");
                return BadRequest("Employee ID mismatch");
            }
            if (update.Name != null)
            {
                contact.Name = update.Name;
            }
            if (update.PhoneNumber != null)
            {
                contact.PhoneNumber = update.PhoneNumber;
            }

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(contact);
        }


        // DELETE: api/Contacts/5
        [HttpDelete("{id}", Name = "Delete")]
        public async Task<IActionResult> DeleteContact(long id)
        {
            try
            {
                if (_context.Contacts == null)
                {
                    return NotFound();
                }
                var contact = await _context.Contacts.FindAsync(id);
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();

                return Content("User ${contact.Name} has been deleted");
            }
            catch (Exception exception)
            {
                _logger.LogError($"Something went wrong inside UpdateOwner action: {exception.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error finding contact.");
            }
        }

        private bool ContactExists(long id)
        {
            return (_context.Contacts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}