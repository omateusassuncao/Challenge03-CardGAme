using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Challenge03.Data;
using Challenge03.Models;

namespace Challenge03.Pages.Batalhas
{
    public class CreateModel : PageModel
    {
        private readonly Challenge03.Data.ApplicationDbContext _context;

        public CreateModel(Challenge03.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Batalha Batalha { get; set; } = default!;
        public Player? PlayerVencedor { get; set; } = default!;
        public List<SelectListItem> ClasseList { get; private set; }
        public List<SelectListItem> AtributoList { get; private set; }

        public IActionResult OnGet()
        {
            ViewData["Player"] = new SelectList(_context.Players, "Id", "Nome");

            ViewData["Card"] = new SelectList(_context.Cards, "Id", "Nome");

            AtributoList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Força", Text = "Força" },
                new SelectListItem { Value = "Defesa", Text = "Defesa" },
                new SelectListItem { Value = "Agilidade", Text = "Agilidade" },
                new SelectListItem { Value = "Inteligência", Text = "Inteligência" }
            };
            return Page();
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Batalhas == null || Batalha == null)
            {
                ViewData["Card"] = new SelectList(_context.Cards.Where(c => c.BaralhoId == Batalha.Player_A.BaralhoId), "Id", "Nome");
                return Page();
            }

            Player playerA = _context.Players.FirstOrDefault(p => p.Id == Batalha.Player_AId);
            Player playerB = _context.Players.FirstOrDefault(p => p.Id == Batalha.Player_BId);
            Card cardA = _context.Cards.FirstOrDefault(c => c.Id == Batalha.Card_AId);
            Card cardB = _context.Cards.FirstOrDefault(c => c.Id == Batalha.Card_BId);

            Batalha batalha = new Batalha(playerA, cardA, Batalha.Escolha_A, playerB, cardB, Batalha.Escolha_B);


            _context.Batalhas.Add(batalha);
            await _context.SaveChangesAsync();

            if (batalha.Vencedor != null)
            {
                int? baralhoIdVencedor = batalha.Vencedor.BaralhoId;
                PlayerVencedor = _context.Players.FirstOrDefault(p => p.BaralhoId == baralhoIdVencedor);
            }
            
            return RedirectToPage("./Index");
        }
    }
}
