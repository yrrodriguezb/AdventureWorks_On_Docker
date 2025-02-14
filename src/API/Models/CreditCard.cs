namespace API.Models;

public class CreditCard
{
    public int CreditCardID { get; set; }
    public string CardType { get; set; } = string.Empty;
    public string CardNumber { get; set; } = string.Empty;
    public byte ExpMonth { get; set; }
    public short ExpYear { get; set; }
    public DateTime ModifiedDate { get; set; }

    public ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new List<SalesOrderHeader>();
}