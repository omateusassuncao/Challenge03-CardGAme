﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly Challenge03.Data.ApplicationDbContext _context;

        public DetailsModel(Challenge03.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Card Card { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cards == null)
            {
                return NotFound();
            }

            var card = await _context.Cards.FirstOrDefaultAsync(m => m.Id == id);
            if (card == null)
            {
                return NotFound();
            }
            else 
            {
                Card = card;
            }
            return Page();
        }
    }
}
