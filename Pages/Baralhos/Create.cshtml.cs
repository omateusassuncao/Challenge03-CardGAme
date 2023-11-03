using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Challenge03.Data;
using Challenge03.Models;

namespace Challenge03.Pages.Baralhos
{
    public class CreateModel : PageModel
    {
        private readonly Challenge03.Data.ApplicationDbContext _context;

        public CreateModel(Challenge03.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "CPF");
            return Page();
        }

        [BindProperty]
        public Baralho Baralho { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Baralhos == null || Baralho == null)
            {
                return Page();
            }

            _context.Baralhos.Add(Baralho);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
