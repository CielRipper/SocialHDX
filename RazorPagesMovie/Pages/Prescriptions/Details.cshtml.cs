using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Prescriptions
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesMovie.Data.SocialHDXContext _context;

        public DetailsModel(RazorPagesMovie.Data.SocialHDXContext context)
        {
            _context = context;
        }

        public Prescription Prescription { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescription.FirstOrDefaultAsync(m => m.PrescriptionId == id);

            if (prescription is not null)
            {
                Prescription = prescription;

                return Page();
            }

            return NotFound();
        }
    }
}
