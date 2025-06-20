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
    public class DeleteModel : PageModel
    {
        private readonly TravelAgencyContext _context;

        public DeleteModel(TravelAgencyContext context)
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

            var tourpackage = await _context.TourPackages.FirstOrDefaultAsync(m => m.Id == id);

            if (tourpackage == null)
            {
                return NotFound();
            }
            else
            {
                TourPackage = tourpackage;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TourPackages == null)
            {
                return NotFound();
            }

            var tourpackage = await _context.TourPackages.FindAsync(id);
            if (tourpackage != null)
            {
                tourpackage.IsDeleted = true;
                _context.TourPackages.Update(TourPackage);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
