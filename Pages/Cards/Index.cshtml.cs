using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Challenge03.Data;
using Challenge03.Models;

namespace Challenge03.Pages.Cards
{
    public class IndexModel : PageModel
    {
        private readonly Challenge03.Data.ApplicationDbContext _context;

        public IndexModel(Challenge03.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Card> Cards { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cards != null)
            {
                Cards = await _context.Cards.Include(c => c.Baralho).ToListAsync();
            }
        }
    }
}
