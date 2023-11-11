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
    public class IndexModel : PageModel
    {
        private readonly Challenge03.Data.ApplicationDbContext _context;

        public IndexModel(Challenge03.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Batalha> Batalhas { get;set; } = default!;
        //public List<Resultado> Resultados { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Batalhas != null)
            {
                Batalhas = await _context.Batalhas.Include(b => b.Vencedor.Baralho.Player).ToListAsync();

                //foreach (Batalha item in Batalhas)
                //{
                //    Baralho? baralho = _context.Baralhos.Include(b => b.Player).FirstOrDefault(b => b.Id == item.Vencedor.BaralhoId);
                //    Resultado resultado = new Resultado(item, baralho.Player);
                //    Resultados.Add(resultado);
                //}
            }
        }
    }

    //public class Resultado
    //{
    //    public Resultado(Batalha batalha, Player? vencedor)
    //    {
    //        this.Batalha = batalha;
    //        Vencedor = vencedor;
    //    }

    //    public Batalha Batalha { get; set; }
    //    public Player? Vencedor { get; set; }
    //}

}
