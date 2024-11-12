using Assignment2_ContactManager.Data;
using Assignment2_ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

// By: Ardan Kasha ID#:000366790
// By: Marek Delorme ID#:000362030


public class ContactsController : Controller
{
    private readonly AppDbContext _context;

    public ContactsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Contacts VIEW.
    public async Task<IActionResult> Index()
    {
        var contacts = await _context.Contacts.Include(c => c.Category).ToListAsync();
        return View(contacts);
    }

    // GET: Contacts/Details/id VIEW.
    public async Task<IActionResult> Details(int? id)
    {
        var contact = await _context.Contacts.Include(c => c.Category)
                           .FirstOrDefaultAsync(c => c.contactId == id);
        if (contact == null)
            return NotFound();
        return View(contact);
    }

    // GET: Contact/AddEdit VIEW.
    public IActionResult AddEdit(int? id)
    {
        // Retrieve categories for the dropdown
        ViewData["Categories"] = _context.Categories.ToList();

        if (id == null)
            return View(new Contact()); // Create view for new contact

        // Load existing contact for editing
        var contact = _context.Contacts.Find(id);
        if (contact == null)
            return NotFound();

        return View(contact);
    }

    // POST: Contact/AddEdit - for new contact or editing existing contact depending on id.
    [HttpPost]
    public IActionResult AddEdit(Contact model)
    {
        if (ModelState.IsValid)
        {
            if (model.contactId == 0) // New contact
            {
                _context.Contacts.Add(model);
            }
            else // Edit existing contact
            {
                _context.Contacts.Update(model);
            }
            _context.SaveChanges();

            return RedirectToAction("Index"); 
        }

        // If ModelState is invalid, return the same view
        ViewData["Categories"] = _context.Categories.ToList(); // Populate categories again
        return View(model);
    }


    // GET: Contact/Delete/id VIEW.
    public async Task<IActionResult> Delete(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);
        if (contact == null)
            return NotFound();
        return View(contact);
    }

    // POST: Contact/Delete/id, Actual deletion.
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        // Find by id, if not null, delete.
        var contact = await _context.Contacts.FindAsync(id);
        if (contact != null)
        {
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }
}
