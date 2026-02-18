namespace Taxes.Calculator
{
    public class Order
    {
        public required string ClientName { get; set; }
        public DateTime EndDate { get; set;}
        public required Budget Budget { get; set; }
    }
}