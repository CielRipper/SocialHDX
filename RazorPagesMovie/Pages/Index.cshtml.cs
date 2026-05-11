using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SocialHDXContext _context;

        public IndexModel(SocialHDXContext context)
        {
            _context = context;
        }

        public int TotalStudents { get; set; }
        public int TotalEvents { get; set; }
        public int TotalPrescriptions { get; set; }
        public int OpenCases { get; set; }

        public IList<Prescription> RecentPrescriptions { get; set; } = new List<Prescription>();

        public async Task OnGetAsync()
        {
            TotalStudents = await _context.Student.CountAsync();
            TotalEvents = await _context.CampusEvent.CountAsync();
            TotalPrescriptions = await _context.Prescription.CountAsync();
            OpenCases = await _context.StudentCase
                .CountAsync(c => c.CaseStatus == "Open" || c.CaseStatus == "In Progress");

            RecentPrescriptions = await _context.Prescription
                .Include(p => p.Student)
                .Include(p => p.Prescriber)
                .Include(p => p.CampusEvent)
                .OrderByDescending(p => p.DateAssigned)
                .Take(5)
                .ToListAsync();
        }
    }
}
