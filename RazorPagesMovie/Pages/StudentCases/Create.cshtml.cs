using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages_StudentCases
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMovie.Data.SocialHDXContext _context;

        public CreateModel(RazorPagesMovie.Data.SocialHDXContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PrescriberId"] = new SelectList(_context.Prescriber, "PrescriberId", "Email");
        ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "Email");
            return Page();
        }

        [BindProperty]
        public StudentCase StudentCase { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.StudentCase.Add(StudentCase);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
