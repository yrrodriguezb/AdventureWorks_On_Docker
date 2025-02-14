namespace API.Models;

public class Customer
{
    public int CustomerID { get; set; }
    public int? PersonID { get; set; }
    public int? StoreID { get; set; }
    public int? TerritoryID { get; set; }
    public string AccountNumber { get; set; } = string.Empty;
    public Guid Rowguid { get; set; }
    public DateTime ModifiedDate { get; set; }

    public Person? Person { get; set; }
    public Store? Store { get; set; }
    public SalesTerritory? SalesTerritory { get; set; }
    public ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new List<SalesOrderHeader>();
}