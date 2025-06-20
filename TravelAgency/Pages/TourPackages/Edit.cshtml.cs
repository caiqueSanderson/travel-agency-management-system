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
        private readonly TravelAgency.Data.TravelAgencyContext _context;

        public EditModel(TravelAgency.Data.TravelAgencyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TourPackage TourPackage { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourpackage =  await _context.TourPackages.FirstOrDefaultAsync(m => m.Id == id);
            if (tourpackage == null)
            {
                return NotFound();
            }
            TourPackage = tourpackage;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TourPackage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourPackageExists(TourPackage.Id))
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

        private bool TourPackageExists(int id)
        {
            return _context.TourPackages.Any(e => e.Id == id);
        }
    }
}
