using System;
using System.Text.Json;
using System.Net.Http;

namespace EldenRing
{
    public class ApiClient
    {
        private readonly string ApiUrl;
        public ApiClient(string ApiUrl)
        {
            this.ApiUrl = ApiUrl;
        }

        public async Task<List<Datos>> GetPersonajesAsync()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(ApiUrl);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Root root = JsonSerializer.Deserialize<Root>(responseBody);
            return root?.Datos;
        }
    }
}