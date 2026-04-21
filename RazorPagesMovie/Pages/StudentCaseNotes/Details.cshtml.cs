using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.StudentCaseNotes
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesMovie.Data.SocialHDXContext _context;

        public DetailsModel(RazorPagesMovie.Data.SocialHDXContext context)
        {
            _context = context;
        }

        public StudentCaseNote StudentCaseNote { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentcasenote = await _context.StudentCaseNote.FirstOrDefaultAsync(m => m.StudentCaseNoteId == id);

            if (studentcasenote is not null)
            {
                StudentCaseNote = studentcasenote;

                return Page();
            }

            return NotFound();
        }
    }
}
