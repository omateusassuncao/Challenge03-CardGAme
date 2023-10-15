using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Challenge03.Data;
using Challenge03.Models;

namespace Challenge03.Pages.Players
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
            return Page();
        }

        [BindProperty]
        public Player Player { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Players == null || Player == null)
            {
                Console.WriteLine("Valid Model: " + ModelState.IsValid.ToString());
                return Page();
            }

            Player player = new Player(Player.Nome, Player.CPF);

            _context.Players.Add(player);

            //await _context.SaveChangesAsync();

            //Player playerexistente = _context.Players.FirstOrDefault(p => p.CPF == Player.CPF);

            Baralho baralho = new Baralho(player);

            _context.Baralhos.Add(baralho);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
