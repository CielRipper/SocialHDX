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

namespace RazorPagesMovie.Pages.StudentCases
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesMovie.Data.SocialHDXContext _context;

        public EditModel(RazorPagesMovie.Data.SocialHDXContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StudentCase StudentCase { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentcase =  await _context.StudentCase.FirstOrDefaultAsync(m => m.StudentCaseId == id);
            if (studentcase == null)
            {
                return NotFound();
            }
            StudentCase = studentcase;
           ViewData["PrescriberId"] = new SelectList(_context.Prescriber, "PrescriberId", "Email");
           ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "Email");
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

            _context.Attach(StudentCase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentCaseExists(StudentCase.StudentCaseId))
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

        private bool StudentCaseExists(int id)
        {
            return _context.StudentCase.Any(e => e.StudentCaseId == id);
        }
    }
}
