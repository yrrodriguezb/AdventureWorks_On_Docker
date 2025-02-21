namespace API.Models;

public class Store
{
    public int BusinessEntityID { get; set; }
    public string Name { get; set; } = string.Empty;
    public int? SalesPersonID { get; set; }
    public string? Demographics { get; set; }
    public Guid Rowguid { get; set; }
    public DateTime ModifiedDate { get; set; }

    public SalesPerson? SalesPerson { get; set; }
    public ICollection<Customer> Customers { get; set; } = new List<Customer>();
}