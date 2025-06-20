using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Models;

namespace TravelAgency.Pages.Destinations
{
    public class EditModel : PageModel
    {
        private readonly TravelAgencyContext _context;
        public EditModel(TravelAgencyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Destination Destination { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Destination = await _context.Destinations.FindAsync(id);

            if (Destination == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Destination).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Destinations.Any(e => e.Id == Destination.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
