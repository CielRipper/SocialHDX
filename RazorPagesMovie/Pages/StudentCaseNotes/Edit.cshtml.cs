using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages_StudentCaseNotes
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesMovie.Data.SocialHDXContext _context;

        public EditModel(RazorPagesMovie.Data.SocialHDXContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StudentCaseNote StudentCaseNote { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentcasenote =  await _context.StudentCaseNote.FirstOrDefaultAsync(m => m.StudentCaseNoteId == id);
            if (studentcasenote == null)
            {
                return NotFound();
            }
            StudentCaseNote = studentcasenote;
           ViewData["PrescriberId"] = new SelectList(_context.Prescriber, "PrescriberId", "Email");
           ViewData["StudentCaseId"] = new SelectList(_context.StudentCase, "StudentCaseId", "StudentCaseId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StudentCaseNote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentCaseNoteExists(StudentCaseNote.StudentCaseNoteId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StudentCaseNoteExists(int id)
        {
            return _context.StudentCaseNote.Any(e => e.StudentCaseNoteId == id);
        }
    }
}
