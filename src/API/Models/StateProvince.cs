namespace API.Models;

public class StateProvince
{
    public int StateProvinceID { get; set; }
    public string StateProvinceCode { get; set; } = string.Empty;
    public string CountryRegionCode { get; set; } = string.Empty;
    public bool IsOnlyStateProvinceFlag { get; set; }
    public string Name { get; set; } = string.Empty;
    public int TerritoryID { get; set; }
    public Guid Rowguid { get; set; }
    public DateTime ModifiedDate { get; set; }

    public CountryRegion CountryRegion { get; set; } = null!;
    public SalesTerritory SalesTerritory { get; set; } = null!;
    public ICollection<Address> Addresses { get; set; } = new List<Address>();
}