namespace API.Models;

public class SalesTerritory
{
    public int TerritoryID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CountryRegionCode { get; set; } = string.Empty;
    public string Group { get; set; } = string.Empty;
    public decimal SalesYTD { get; set; }
    public decimal SalesLastYear { get; set; }
    public decimal CostYTD { get; set; }
    public decimal CostLastYear { get; set; }
    public Guid Rowguid { get; set; }
    public DateTime ModifiedDate { get; set; }

    public CountryRegion CountryRegion { get; set; } = null!;
    public ICollection<SalesPerson> SalesPersons { get; set; } = new List<SalesPerson>();
    public ICollection<Customer> Customers { get; set; } = new List<Customer>();
    public ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new List<SalesOrderHeader>();
}