namespace Taxes.Calculator.Adapter
{
    public class IdentityWebAdapter : IHttpAdapter
    {
        public async Task<string> PostAsync(string url, object data)
        {
            return await Task.FromResult($"Simulated response for URL: {url} with data: {data}");
        }
    }
}