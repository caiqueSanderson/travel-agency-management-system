using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Models;

namespace TravelAgency.Pages.Reservations
{
    public class IndexModel : PageModel
    {
        private readonly TravelAgencyContext _context;

        public IndexModel(TravelAgencyContext context)
        {
            _context = context;
        }

        public IList<Reservation> ReservationList { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ReservationList = await _context.Reservations
                .Where(r => !r.IsDeleted)
                .Include(r => r.Client)
                .Include(r => r.TourPackage)
                .ToListAsync();
        }
    }
}
