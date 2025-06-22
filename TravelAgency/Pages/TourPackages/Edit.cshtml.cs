using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Models;

namespace TravelAgency.Pages.TourPackages
{
    public class EditModel : PageModel
    {
        private readonly TravelAgencyContext _context;

        public EditModel(TravelAgencyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TourPackage TourPackage { get; set; } = default!;

        [BindProperty]
        public List<int> SelectedDestinations { get; set; } = new();

        public List<Destination> AvailableDestinations { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TourPackage = await _context.TourPackages
                .Include(tp => tp.Destinations)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (TourPackage == null)
                return NotFound();

            SelectedDestinations = TourPackage.Destinations.Select(d => d.Id).ToList();
            await LoadDestinationsAsync();

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
                return NotFound();

            var tourPackageToUpdate = await _context.TourPackages
                .Include(tp => tp.Destinations)
                .FirstOrDefaultAsync(tp => tp.Id == id);

            if (tourPackageToUpdate == null)
                return NotFound();

            await LoadDestinationsAsync();

            if (await TryUpdateModelAsync(
                tourPackageToUpdate,
                "TourPackage",
                tp => tp.Title, tp => tp.StartDate,
                tp => tp.Price, tp => tp.MaxCapacity))
            {
                // Atualizar os destinos selecionados
                tourPackageToUpdate.Destinations = await _context.Destinations
                    .Where(d => SelectedDestinations.Contains(d.Id))
                    .ToListAsync();

                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool TourPackageExists(int id)
        {
            return _context.TourPackages.Any(e => e.Id == id);
        }

        private async Task LoadDestinationsAsync()
        {
            AvailableDestinations = await _context.Destinations
                .Where(d => !d.IsDeleted)
                .ToListAsync();
        }
    }
}
