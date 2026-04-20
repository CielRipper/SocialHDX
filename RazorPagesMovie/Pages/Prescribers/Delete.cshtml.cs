using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages_Prescribers
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesMovie.Data.SocialHDXContext _context;

        public DeleteModel(RazorPagesMovie.Data.SocialHDXContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Prescriber Prescriber { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescriber = await _context.Prescriber.FirstOrDefaultAsync(m => m.PrescriberId == id);

            if (prescriber is not null)
            {
                Prescriber = prescriber;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescriber = await _context.Prescriber.FindAsync(id);
            if (prescriber != null)
            {
                Prescriber = prescriber;
                _context.Prescriber.Remove(Prescriber);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
