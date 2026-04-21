using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.StudentCases
{
    public class IndexModel : PageModel
    {
        private readonly SocialHDXContext _context;

        public IndexModel(SocialHDXContext context)
        {
            _context = context;
        }

        public IList<StudentCase> StudentCase { get; set; } = default!;

        public async Task OnGetAsync()
        {
            StudentCase = await _context.StudentCase
                .Include(s => s.Student)
                .Include(s => s.Prescriber)
                .ToListAsync();
        }
    }
}