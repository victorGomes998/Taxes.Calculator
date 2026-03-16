namespace Taxes.Calculator.Adapter
{
    public class RegisterBudget
    {
        private readonly IHttpAdapter _httpAdapter;

        public RegisterBudget(IHttpAdapter httpAdapter)
        {
            _httpAdapter = httpAdapter;
        }

        public async Task<string> RegisterAsync(Budget budget)
        {
            var url = "https://api.example.com/register-budget";
            return await _httpAdapter.PostAsync(url, budget);
        }
    }
}