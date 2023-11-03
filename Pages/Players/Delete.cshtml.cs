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
    public class DeleteModel : PageModel
    {
        private readonly Challenge03.Data.ApplicationDbContext _context;

        public DeleteModel(Challenge03.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Player Player { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Players == null)
            {
                return NotFound();
            }

            var player = await _context.Players.FirstOrDefaultAsync(m => m.Id == id);

            if (player == null)
            {
                return NotFound();
            }
            else 
            {
                Player = player;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Players == null)
            {
                return NotFound();
            }
            var player = await _context.Players.FindAsync(id);

            if (player != null)
            {
                Player = player;
                _context.Players.Remove(Player);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
