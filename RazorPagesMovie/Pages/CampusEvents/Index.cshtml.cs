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

        public SelectList? Categories { get; set; }

        public string? EventCategory { get; set; }

        public string? SearchString { get; set; }

        public async Task OnGetAsync(string eventCategory, string searchString)
        {
            EventCategory = eventCategory;
            SearchString = searchString;

            IQueryable<string> categoryQuery = from e in _context.CampusEvent
                                               orderby e.Category
                                               select e.Category;

            var events = from e in _context.CampusEvent
                         select e;

            if (!string.IsNullOrEmpty(searchString))
            {
                events = events.Where(e =>
                    e.Title.Contains(searchString) ||
                    e.Description.Contains(searchString) ||
                    e.Location.Contains(searchString)
                );
            }
            if (!string.IsNullOrEmpty(eventCategory))
            {
                events = events.Where(e => e.Category == eventCategory);
            }

            Categories = new SelectList(await categoryQuery.Distinct().ToListAsync());

            CampusEvent = await events.ToListAsync();
        }
    }
}