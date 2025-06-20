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
    public class IndexModel : PageModel
    {
        private readonly TravelAgencyContext _context;

        public IndexModel(TravelAgencyContext context)
        {
            _context = context;
        }

        public List<TourPackage> TourPackages { get;set; } = new();

        public async Task OnGetAsync()
        {
            TourPackages = await _context.TourPackages.ToListAsync();
        }
    }
}
