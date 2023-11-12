using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Challenge03.Data;
using Challenge03.Models;

namespace Challenge03.Pages.Baralhos
{
    public class DeleteModel : PageModel
    {
        private readonly Challenge03.Data.ApplicationDbContext _context;

        public DeleteModel(Challenge03.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Baralho Baralho { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Baralhos == null)
            {
                return NotFound();
            }

            var baralho = await _context.Baralhos.FirstOrDefaultAsync(m => m.Id == id);

            if (baralho == null)
            {
                return NotFound();
            }
            else 
            {
                Baralho = baralho;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Baralhos == null)
            {
                return NotFound();
            }
            var baralho = await _context.Baralhos.FindAsync(id);

            if (baralho != null)
            {
                Baralho = baralho;
                _context.Baralhos.Remove(Baralho);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
