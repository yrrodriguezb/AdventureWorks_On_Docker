namespace API.Models;

public class CountryRegion
{
    public string CountryRegionCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public DateTime ModifiedDate { get; set; }

    public ICollection<SalesTerritory> SalesTerritories { get; set; } = new List<SalesTerritory>();
}