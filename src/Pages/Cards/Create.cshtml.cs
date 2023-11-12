using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Challenge03.Models;
using Newtonsoft.Json;
using Challenge03.Data;

namespace Challenge03.Pages.Cards
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
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

            string textToSearch = Card.TextoParaImagem /*+ " " + Card.Elemento*/;
            string aiResult = GetGoogleImage(textToSearch).Result.ToString();
            Baralho baralho = _context.Baralhos.FirstOrDefault(b => b.Id == Card.BaralhoId);
            Card card = new Card(Card.Nome, Card.Historia, Card.TextoParaImagem, Card.Classe, Card.Elemento, aiResult, Card.Assinatura, baralho);  

            _context.Cards.Add(card);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
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

        ////Código utilizado para busca na OpenAI
        //static async Task<string> GetAIIMage(string prompt)
        //{
        //    string apiKey = "AIzaSyC4ehfwsrgNhaO7UPchntMAy5gy-gnH9-A";
        //    string apiUrl = "https://api.openai.com/v1/images/generations";
        //    int n = 1;
        //    string size = "512x512";

        //    var client = new HttpClient();
        //    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        //    var requestContent = new
        //    {
        //        prompt,
        //        n,
        //        size
        //    };

        //    var response = await client.PostAsJsonAsync(apiUrl, requestContent);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var jsonContent = await response.Content.ReadAsStringAsync();
        //        var result = JsonSerializer.Deserialize<OpenAIImageResponse>(jsonContent);

        //        // O resultado contém as imagens geradas. Você pode processá-las conforme necessário.
        //        //foreach (var image in result.choices)
        //        //{
        //        //    Console.WriteLine($"URL da imagem: {image.url}");
        //        //}

        //        return result.data[0].url;
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Erro na solicitação: {response.ReasonPhrase}");
        //        return "erro";
        //    }

        //}


    }
}

public class Search
{
    public List<Item> Items { get; set; }
}

public class Item
{
    public Pagemap Pagemap { get; set; }
}

public class Pagemap
{
    public List<CseImage> cse_image { get; set; }
}

public class CseImage
{
    public CseImage()
    {
        src = null;
    }

    public string src { get; set; }
}

public class OpenAIImageResponse
{
    public List<OpenAIImageData> data { get; set; }
}

public class OpenAIImageData
{
    public string url { get; set; }
}
