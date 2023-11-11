using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Challenge03.Data;
using Challenge03.Models;

namespace Challenge03.Pages.Players
{
    public class DetailsModel : PageModel
    {
        private readonly Challenge03.Data.ApplicationDbContext _context;

        public DetailsModel(Challenge03.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Player Player { get; set; } = default!;
      public Baralho Baralho { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Players == null)
            {
                return NotFound();
            }

            var player = await _context.Players.FirstOrDefaultAsync(m => m.Id == id);
            var baralho = await _context.Baralhos.FirstOrDefaultAsync(m => m.PlayerId == id);
            Console.WriteLine("BARALHO: " +baralho.Name);
            if (player == null)
            {
                return NotFound();
            }
            else 

            {
                Player = player;
                Baralho = baralho;
            }
            return Page();
        }
    }
}
