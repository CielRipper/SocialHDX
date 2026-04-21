using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.CampusEvents
{
    public class IndexModel : PageModel
    {
        private readonly SocialHDXContext _context;

        public IndexModel(SocialHDXContext context)
        {
            _context = context;
        }

        public IList<CampusEvent> CampusEvent { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? EventCategory { get; set; }

        public SelectList? Categories { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> categoryQuery = from e in _context.CampusEvent
                                               orderby e.Category
                                               select e.Category;

            IQueryable<CampusEvent> eventsIQ = from e in _context.CampusEvent
                                               select e;

            if (!string.IsNullOrEmpty(SearchString))
            {
                eventsIQ = eventsIQ.Where(e => e.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(EventCategory))
            {
                eventsIQ = eventsIQ.Where(e => e.Category == EventCategory);
            }

            Categories = new SelectList(await categoryQuery.Distinct().ToListAsync());
            CampusEvent = await eventsIQ.ToListAsync();
        }
    }
}