using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Challenge03.Data;
using Challenge03.Models;
using Newtonsoft.Json;

namespace Challenge03.Pages.Cards
{
    public class EditModel : PageModel
    {
        private readonly Challenge03.Data.ApplicationDbContext _context;

        public EditModel(Challenge03.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Card Card { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            ViewData["Baralho"] = new SelectList(_context.Baralhos, "Id", "Name");

            if (id == null || _context.Cards == null)
            {
                return NotFound();
            }

            var card =  await _context.Cards.FirstOrDefaultAsync(m => m.Id == id);
            if (card == null)
            {
                return NotFound();
            }
            Card = card;

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            var card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == Card.Id);
            card.Nome = Card.Nome;
            card.Historia = Card.Historia;
            card.ImageUrl = Card.ImageUrl;
            card.Assinatura = Card.Assinatura;

            _context.Cards.Update(card);
            var result = await _context.SaveChangesAsync();

            if (result == null)
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }

        private bool CardExists(int id)
        {
          return (_context.Cards?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
