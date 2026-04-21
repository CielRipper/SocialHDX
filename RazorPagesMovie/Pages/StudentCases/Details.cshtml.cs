using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.StudentCases
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesMovie.Data.SocialHDXContext _context;

        public DetailsModel(RazorPagesMovie.Data.SocialHDXContext context)
        {
            _context = context;
        }

        public StudentCase StudentCase { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentcase = await _context.StudentCase.FirstOrDefaultAsync(m => m.StudentCaseId == id);

            if (studentcase is not null)
            {
                StudentCase = studentcase;

                return Page();
            }

            return NotFound();
        }
    }
}
