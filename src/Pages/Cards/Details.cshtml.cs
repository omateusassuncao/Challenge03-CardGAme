using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Challenge03.Data;
using Challenge03.Models;
using Newtonsoft.Json;

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


        public async Task<IActionResult> OnGetChangeGoogleImage(int? id)
        {

            var card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);

            string textToSearch = card.TextoParaImagem /*+ " " + Card.Elemento*/;
            string aiResult = GetGoogleImage(textToSearch).Result.ToString();

            card.ImageUrl = aiResult;

            Card = card;

            _context.Cards.Update(Card);
            var result = await _context.SaveChangesAsync();

            if (result == null)
            {
                return NotFound();
            }

            return Page();
        }
            
        //Còdigo utilizado para busca no google utizando Google API
        static async Task<string> GetGoogleImage(string textToSearch)
        {
            string cseId = "3599d0fa2138f4b50";
            string apiKey = "AIzaSyC4ehfwsrgNhaO7UPchntMAy5gy-gnH9-A";
            string numItens = "10";
            string apiUrl = "https://www.googleapis.com/customsearch/v1?cx={cx}&key={key}&q={query}&num={num}";
            string query = "Monster " + textToSearch + "oil painting";

            var client = new HttpClient();
            var uri = new Uri(apiUrl.Replace("{query}", query).Replace("{cx}", cseId).Replace("{key}", apiKey).Replace("{num}", numItens));
            //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                // Decodifica a resposta JSON
                var json = await response.Content.ReadAsStringAsync();

                var search = JsonConvert.DeserializeObject<Search>(json);

                var imageList = new List<string>();

                foreach (var item in search.Items)
                {
                    if (item.Pagemap.cse_image != null && item.Pagemap.cse_image[0].src != null)
                    {
                        imageList.Add(item.Pagemap.cse_image[0].src);
                    }
                }
                string imgUrl = null;

                while (imgUrl == null)
                {
                    int randomNumber = (new Random()).Next(0, imageList.Count()-1);
                    imgUrl = imageList[randomNumber];
                    //cseImage = search.Items.Select(item => item.Pagemap.cse_image[randomNumber]).FirstOrDefault();
                    //cseImage = search.Items.Select(item => item.Pagemap.cse_image[randomNumber]).FirstOrDefault();
                }

                //cseImage = search.Items.Select(item => item.Pagemap.cse_image[randomNumber]).FirstOrDefault();
                return imgUrl;

            }
            else
            {
                // Lança uma exceção
                throw new Exception("Erro ao buscar imagens: " + response.StatusCode);
            }

        }
    }
}
