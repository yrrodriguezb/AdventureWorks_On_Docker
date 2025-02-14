namespace API.Models;

public class SalesOrderHeader
{
    public int SalesOrderID { get; set; }
    public byte RevisionNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ShipDate { get; set; }
    public byte Status { get; set; }
    public bool OnlineOrderFlag { get; set; }
    public string SalesOrderNumber { get; set; } = string.Empty;
    public string? PurchaseOrderNumber { get; set; }
    public string? AccountNumber { get; set; }
    public int CustomerID { get; set; }
    public int? SalesPersonID { get; set; }
    public int? TerritoryID { get; set; }
    public int BillToAddressID { get; set; }
    public int ShipToAddressID { get; set; }
    public int ShipMethodID { get; set; }
    public int? CreditCardID { get; set; }
    public string? CreditCardApprovalCode { get; set; }
    public int? CurrencyRateID { get; set; }
    public decimal SubTotal { get; set; }
    public decimal TaxAmt { get; set; }
    public decimal Freight { get; set; }
    public decimal TotalDue { get; set; }
    public string? Comment { get; set; }
    public Guid Rowguid { get; set; }
    public DateTime ModifiedDate { get; set; }

    public Address BillToAddress { get; set; } = null!;
    public Address ShipToAddress { get; set; } = null!;
    public CreditCard? CreditCard { get; set; }
    public CurrencyRate? CurrencyRate { get; set; }
    public Customer Customer { get; set; } = null!;
    public SalesPerson? SalesPerson { get; set; }
    public SalesTerritory? SalesTerritory { get; set; }
    public ShipMethod ShipMethod { get; set; } = null!;   
}