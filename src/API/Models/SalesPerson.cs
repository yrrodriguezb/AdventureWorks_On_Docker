namespace API.Models;

public class SalesPerson
    {
        public int BusinessEntityID { get; set; }
        public int? TerritoryID { get; set; }
        public decimal? SalesQuota { get; set; }
        public decimal Bonus { get; set; }
        public decimal CommissionPct { get; set; }
        public decimal SalesYTD { get; set; }
        public decimal SalesLastYear { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Employee Employee { get; set; } = null!;
        public SalesTerritory? SalesTerritory { get; set; }
        public ICollection<Store> Stores { get; set; } = new List<Store>();
        public ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new List<SalesOrderHeader>();
    }