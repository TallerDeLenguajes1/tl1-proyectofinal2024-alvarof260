using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Proyecto
{
    public class Genero
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("gender")]
        public string Gender { get; set; }
        [JsonPropertyName("probability")]
        public double Probability { get; set; }
    }

    public static class ConsumirApi
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<Genero> GetGenderByNameAsync(string name)
        {
            string url = $"https://api.genderize.io/?name={name}";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Genero>(responseBody);
        }
    }

}