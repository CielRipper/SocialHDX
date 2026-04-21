using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.CampusEvents
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesMovie.Data.SocialHDXContext _context;

        public DetailsModel(RazorPagesMovie.Data.SocialHDXContext context)
        {
            _context = context;
        }

        public CampusEvent CampusEvent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campusevent = await _context.CampusEvent.FirstOrDefaultAsync(m => m.CampusEventId == id);

            if (campusevent is not null)
            {
                CampusEvent = campusevent;

                return Page();
            }

            return NotFound();
        }
    }
}
