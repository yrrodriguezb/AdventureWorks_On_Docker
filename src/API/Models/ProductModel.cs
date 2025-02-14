namespace API.Models;

public class ProductModel
{
    public int ProductModelID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? CatalogDescription { get; set; }
    public string? Instructions { get; set; }
    public Guid Rowguid { get; set; }
    public DateTime ModifiedDate { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}