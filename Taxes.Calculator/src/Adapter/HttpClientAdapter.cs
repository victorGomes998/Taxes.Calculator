using System.Text;
using System.Text.Json;

namespace Taxes.Calculator.Adapter
{
    public class HttpClientAdapter : IHttpAdapter
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<string> PostAsync(string url, object data)
        {
            var jsonData = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}