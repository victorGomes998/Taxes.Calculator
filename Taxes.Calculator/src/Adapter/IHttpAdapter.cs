namespace Taxes.Calculator.Adapter
{
    public interface IHttpAdapter
    {
        Task<string> PostAsync(string url, object data);
    }
}