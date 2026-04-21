using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Prescriptions
{
    public class CreateModel : PageModel
    {
        private readonly SocialHDXContext _context;

        public CreateModel(SocialHDXContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "FirstName");
            ViewData["PrescriberId"] = new SelectList(_context.Prescriber, "PrescriberId", "FirstName");
            ViewData["CampusEventId"] = new SelectList(_context.CampusEvent, "CampusEventId", "Title");
            return Page();
        }

        [BindProperty]
        public Prescription Prescription { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "FirstName");
                ViewData["PrescriberId"] = new SelectList(_context.Prescriber, "PrescriberId", "FirstName");
                ViewData["CampusEventId"] = new SelectList(_context.CampusEvent, "CampusEventId", "Title");
                return Page();
            }

            _context.Prescription.Add(Prescription);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}