namespace API.Models;

public class CurrencyRate
{
    public int CurrencyRateID { get; set; }
    public DateTime CurrencyRateDate { get; set; }
    public string FromCurrencyCode { get; set; } = string.Empty;
    public string ToCurrencyCode { get; set; } = string.Empty;
    public decimal AverageRate { get; set; }
    public decimal EndOfDayRate { get; set; }
    public DateTime ModifiedDate { get; set; }

    public Currency FromCurrency { get; set; } = null!;
    public Currency ToCurrency { get; set; } = null!;
    public ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new List<SalesOrderHeader>();
}