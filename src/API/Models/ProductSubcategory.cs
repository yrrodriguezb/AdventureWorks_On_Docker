namespace API.Models;

public class ProductSubcategory
{
    public int ProductSubcategoryID { get; set; }
    public int ProductCategoryID { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid Rowguid { get; set; }
    public DateTime ModifiedDate { get; set; }

    public ProductCategory ProductCategory { get; set; } = null!;
    public ICollection<Product> Products { get; set; } = new List<Product>();
}