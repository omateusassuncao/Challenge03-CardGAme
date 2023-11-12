using System.Net;

public class HelperIntegration
{
    public HelperIntegration()
    {
    }

    public async Task<HttpStatusCode> SenderAsync(string textToSearch)
    {
        string cseId = "3599d0fa2138f4b50";
        string apiKey = "AIzaSyC4ehfwsrgNhaO7UPchntMAy5gy-gnH9-A";
        string numItens = "10";
        string apiUrl = "https://www.googleapis.com/customsearch/v1?cx={cx}&key={key}&q={query}&num={num}";
        string query = "Monster " + textToSearch + "oil painting";

        using (var client = new HttpClient())
        {
            var uri = new Uri(apiUrl.Replace("{query}", query).Replace("{cx}", cseId).Replace("{key}", apiKey).Replace("{num}", numItens));

            try
            {
                var response = await client.GetAsync(uri);
                return response.StatusCode;
            }
            catch (HttpRequestException ex)
            {
                // Log the exception message and then rethrow, or handle the exception here.
                throw;
            }
        }
    }
}
