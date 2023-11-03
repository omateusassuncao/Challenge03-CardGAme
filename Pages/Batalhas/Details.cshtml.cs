using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Challenge03.Data;
using Challenge03.Models;

namespace Challenge03.Pages.Batalhas
{
    public class DetailsModel : PageModel
    {
        private readonly Challenge03.Data.ApplicationDbContext _context;

        public DetailsModel(Challenge03.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Batalha Batalha { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Batalhas == null)
            {
                return NotFound();
            }

            var batalha = await _context.Batalhas.Include(b => b.Vencedor.Baralho.Player).FirstOrDefaultAsync(m => m.Id == id);
            if (batalha == null)
            {
                return NotFound();
            }
            else 
            {
                Batalha = batalha;
            }
            return Page();
        }
    }
}
