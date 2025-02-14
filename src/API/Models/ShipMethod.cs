namespace API.Models;

public class ShipMethod
{
    public int ShipMethodID { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal ShipBase { get; set; }
    public decimal ShipRate { get; set; }
    public Guid Rowguid { get; set; }
    public DateTime ModifiedDate { get; set; }

    public ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new List<SalesOrderHeader>();
}