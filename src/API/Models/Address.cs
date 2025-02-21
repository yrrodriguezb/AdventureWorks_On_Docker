namespace API.Models;

public class Address
{
    public int AddressID { get; set; }
    public string AddressLine1 { get; set; } = string.Empty;
    public string? AddressLine2 { get; set; }
    public string City { get; set; } = string.Empty;
    public int StateProvinceID { get; set; }
    public string PostalCode { get; set; } = string.Empty;
    public string? SpatialLocation { get; set; }
    public Guid Rowguid { get; set; }
    public DateTime ModifiedDate { get; set; }

    public StateProvince StateProvince { get; set; } = null!;
    public ICollection<SalesOrderHeader> BillToSalesOrderHeaders { get; set; } = new List<SalesOrderHeader>();
    public ICollection<SalesOrderHeader> ShipToSalesOrderHeaders { get; set; } = new List<SalesOrderHeader>();
}