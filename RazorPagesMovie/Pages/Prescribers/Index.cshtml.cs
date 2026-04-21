using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Prescribers
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.SocialHDXContext _context;

        public IndexModel(RazorPagesMovie.Data.SocialHDXContext context)
        {
            _context = context;
        }

        public IList<Prescriber> Prescriber { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Prescriber = await _context.Prescriber.ToListAsync();
        }
    }
}
