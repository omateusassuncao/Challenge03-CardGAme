using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Challenge03.Data;
using Challenge03.Models;
using System.Xml.Linq;
using System.Text.Json;
using System.Drawing;

namespace Challenge03.Pages.Cards
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

            ViewData["Baralho"] = new SelectList(_context.Baralhos, "Id", "Name");

            ClasseList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Guerreiro", Text = "Guerreiro" },
                new SelectListItem { Value = "Mago", Text = "Mago" },
                new SelectListItem { Value = "Arqueiro", Text = "Arqueiro" },
                new SelectListItem { Value = "Ladrão", Text = "Ladrão" }
            };

            ElementosList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Água", Text = "Água" },
                new SelectListItem { Value = "Fogo", Text = "Fogo" },
                new SelectListItem { Value = "Ar", Text = "Ar" },
                new SelectListItem { Value = "Terra", Text = "Terra" }
            };

            return Page();
        }

        [BindProperty]
        public Card Card { get; set; } = default!;
        public List<SelectListItem> ClasseList { get; private set; }
        public List<SelectListItem> ElementosList { get; private set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Cards == null || Card == null)
            {
                return Page();
            }

            string textToAi = /*Card.Classe + " " + */Card.ImageUrl/* + "of" + Card.Elemento*/;
            string aiResult = GetAIIMage(textToAi).Result.ToString();
            Card card = new Card(Card.Nome, Card.Historia, Card.Classe, Card.Elemento, aiResult, Card.Assinatura);  

            _context.Cards.Add(card);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        static async Task<string> GetAIIMage(string prompt)
        {
            string apiKey = "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";
            string apiUrl = "https://api.openai.com/v1/images/generations";
            int n = 1;
            string size = "512x512";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            var requestContent = new
            {
                prompt,
                n,
                size
            };

            var response = await client.PostAsJsonAsync(apiUrl, requestContent);

            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<OpenAIImageResponse>(jsonContent);

                // O resultado contém as imagens geradas. Você pode processá-las conforme necessário.
                //foreach (var image in result.choices)
                //{
                //    Console.WriteLine($"URL da imagem: {image.url}");
                //}

                return result.data[0].url;
            }
            else
            {
                Console.WriteLine($"Erro na solicitação: {response.ReasonPhrase}");
                return "erro";
            }

        }


    }
}

public class OpenAIImageResponse
{
    public List<OpenAIImageData> data { get; set; }
}

public class OpenAIImageData
{
    public string url { get; set; }
}
