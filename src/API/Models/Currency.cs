namespace API.Models;

public class Currency
{
    public string CurrencyCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public DateTime ModifiedDate { get; set; }

    public ICollection<CurrencyRate> FromCurrencyRates { get; set; } = new List<CurrencyRate>();
    public ICollection<CurrencyRate> ToCurrencyRates { get; set; } = new List<CurrencyRate>();
}