using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.StudentCases
{
    public class CreateModel : PageModel
    {
        private readonly SocialHDXContext _context;

        public CreateModel(SocialHDXContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StudentCase StudentCase { get; set; } = new StudentCase();

        public IActionResult OnGet()
        {
            LoadSelections();
            StudentCase.OpenedDate = DateTime.Now;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                LoadSelections();
                return Page();
            }

            _context.StudentCase.Add(StudentCase);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        private void LoadSelections()
        {
            ViewData["StudentId"] = new SelectList(
                _context.Student,
                "StudentId",
                "FirstName"
            );

            ViewData["PrescriberId"] = new SelectList(
                _context.Prescriber,
                "PrescriberId",
                "FirstName"
            );
        }
    }
}