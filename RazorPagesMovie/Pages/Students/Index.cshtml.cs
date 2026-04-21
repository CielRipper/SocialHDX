using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly SocialHDXContext _context;

        public IndexModel(SocialHDXContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<Student> studentsIQ = from s in _context.Student
                                             select s;

            if (!string.IsNullOrEmpty(SearchString))
            {
                studentsIQ = studentsIQ.Where(s =>
                    s.FirstName.Contains(SearchString) ||
                    s.LastName.Contains(SearchString) ||
                    s.StudentNumber.Contains(SearchString));
            }

            Student = await studentsIQ.ToListAsync();
        }
    }
}