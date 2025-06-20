using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Models;

namespace TravelAgency.Pages.Destinations
{
    public class DetailsModel : PageModel
    {
        private readonly TravelAgency.Data.TravelAgencyContext _context;

        public DetailsModel(TravelAgency.Data.TravelAgencyContext context)
        {
            _context = context;
        }

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
    }
}
