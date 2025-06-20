﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly TravelAgency.Data.TravelAgencyContext _context;

        public DetailsModel(TravelAgency.Data.TravelAgencyContext context)
        {
            _context = context;
        }

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
    }
}
