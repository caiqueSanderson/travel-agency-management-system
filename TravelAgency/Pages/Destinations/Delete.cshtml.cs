using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Models;

namespace TravelAgency.Pages.Destinations
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly TravelAgencyContext _context;

        public DeleteModel(TravelAgencyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Destination Destination { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destination = await _context.Destinations.FirstOrDefaultAsync(m => m.Id == id);

            if (destination == null)
            {
                return NotFound();
            }
            else
            {
                Destination = destination;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Destinations == null)
            {
                return NotFound();
            }

            var destination = await _context.Destinations.FindAsync(id);
            if (destination != null)
            {
                destination.IsDeleted = true; 
                _context.Destinations.Update(Destination);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
