namespace API.Models;

 public class SalesTerritoryHistory
{
    public int BusinessEntityID { get; set; }
    public int TerritoryID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public Guid Rowguid { get; set; }
    public DateTime ModifiedDate { get; set; }

    public SalesPerson SalesPerson { get; set; } = null!;
    public SalesTerritory SalesTerritory { get; set; } = null!;
}
    
        