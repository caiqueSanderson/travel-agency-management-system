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
    public class DetailsModel : PageModel
    {
        private readonly TravelAgencyContext _context;

        public DetailsModel(TravelAgencyContext context)
        {
            _context = context;
        }

        public Reservation Reservation { get; set; } = default!;
        public bool IsFull { get; set; } = false;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Client)
                .Include(r => r.TourPackage)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (reservation == null)
            {
                return NotFound();
            }
            else
            {
                Reservation = reservation;
            }

            var totalReservations = await _context.Reservations
            .CountAsync(r => r.TourPackageId == Reservation.TourPackageId && !r.IsDeleted);

            IsFull = totalReservations >= Reservation.TourPackage.MaxCapacity;

            return Page();
        }
    }
}
