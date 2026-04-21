using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Prescriptions
{
    public class IndexModel : PageModel
    {
        private readonly SocialHDXContext _context;

        public IndexModel(SocialHDXContext context)
        {
            _context = context;
        }

        public IList<Prescription> Prescription { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Prescription = await _context.Prescription
                .Include(p => p.Student)
                .Include(p => p.Prescriber)
                .Include(p => p.CampusEvent)
                .ToListAsync();
        }
    }
}