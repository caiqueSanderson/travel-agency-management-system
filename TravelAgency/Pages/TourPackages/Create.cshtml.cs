using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Models;

namespace TravelAgency.Pages.TourPackages
{
    public class CreateModel : PageModel
    {
        private readonly TravelAgencyContext _context;

        public CreateModel(TravelAgencyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TourPackage TourPackage { get; set; } = default!;

        [BindProperty]
        public List<int> SelectedDestinations { get; set; } = new();

        public List<Destination> AvailableDestinations { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            await LoadDestinationsAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await LoadDestinationsAsync();

            if (!ModelState.IsValid)
                return Page();

            if (SelectedDestinations.Any())
            {
                TourPackage.Destinations = await _context.Destinations
                    .Where(d => SelectedDestinations.Contains(d.Id))
                    .ToListAsync();
            }

            _context.TourPackages.Add(TourPackage);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private async Task LoadDestinationsAsync()
        {
            AvailableDestinations = await _context.Destinations
                .Where(d => !d.IsDeleted)
                .ToListAsync();
        }
    }
}
