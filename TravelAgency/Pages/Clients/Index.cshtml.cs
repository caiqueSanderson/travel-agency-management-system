using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Models;

namespace TravelAgency.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly TravelAgencyContext _context;

        public IndexModel(TravelAgencyContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Client = await _context.Clients
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }
    }
}
