using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelAgency.Data;
using TravelAgency.Models;

namespace TravelAgency.Pages.Destinations
{
    public class CreateModel : PageModel
    {
        private readonly TravelAgencyContext _context;

        public CreateModel(TravelAgencyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Destination Destination { get; set; } = new();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Destinations.Add(Destination);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
