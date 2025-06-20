using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelAgency.Data;
using TravelAgency.Models;

namespace TravelAgency.Pages.Reservations
{
    public class CreateModel : PageModel
    {
        private readonly TravelAgencyContext _context;

        public CreateModel(TravelAgencyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reservation Reservation { get; set; } = default!;

        public SelectList ClientList { get; set; }
        public SelectList TourPackageList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            await LoadListsAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await LoadListsAsync();

            if (!ModelState.IsValid)
                return Page();

            var tourPackage = await _context.TourPackages
                .FirstOrDefaultAsync(p => p.Id == Reservation.TourPackageId && !p.IsDeleted);

            if (tourPackage == null)
            {
                ModelState.AddModelError(string.Empty, "Pacote turístico não encontrado.");
                return Page();
            }

            if (tourPackage.StartDate <= DateTime.Today)
            {
                ModelState.AddModelError(string.Empty, "Não é possível reservar pacotes com data passada ou já iniciados.");
                return Page();
            }

            if (Reservation.ReservationDate >= tourPackage.StartDate)
            {
                ModelState.AddModelError(string.Empty, "A data da reserva deve ser posterior ou igual à data de início do pacote.");
                return Page();
            }

            var existingReservation = await _context.Reservations
                .AnyAsync(r => r.ClientId == Reservation.ClientId
                            && r.TourPackageId == Reservation.TourPackageId
                            && r.ReservationDate == Reservation.ReservationDate
                            && !r.IsDeleted);

            if (existingReservation)
            {
                ModelState.AddModelError(string.Empty, "Este cliente já possui uma reserva para este pacote na mesma data.");
                return Page();
            }

            var totalReservations = await _context.Reservations
                .CountAsync(r => r.TourPackageId == Reservation.TourPackageId && !r.IsDeleted);

            if (totalReservations >= tourPackage.MaxCapacity)
            {
                ModelState.AddModelError(string.Empty, "Não é possível reservar. O pacote está lotado.");
                return Page();
            }

            _context.Reservations.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private async Task LoadListsAsync()
        {
            var clients = await _context.Clients.Where(c => !c.IsDeleted).ToListAsync();
            var tourPackages = await _context.TourPackages.Where(p => !p.IsDeleted).ToListAsync();

            ClientList = new SelectList(clients, "Id", "Name");
            TourPackageList = new SelectList(tourPackages, "Id", "Title");
        }
    }
}
