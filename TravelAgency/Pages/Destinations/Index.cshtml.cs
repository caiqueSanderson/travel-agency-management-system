using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Models;

namespace TravelAgency.Pages.Destinations
{
    public class IndexModel : PageModel
    {
        private readonly TravelAgencyContext _context;

        public IndexModel(TravelAgencyContext context)
        {
            _context = context;
        }

        public List<Destination> Destinations { get; set; } = new();

        public async Task OnGetAsync()
        {
            Destinations = await _context.Destinations
                .Where(d => !d.IsDeleted)
                .ToListAsync();
        }
    }
}
