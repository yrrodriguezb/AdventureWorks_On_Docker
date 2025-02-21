namespace API.Models;

public class ProductCategory
{
    public int ProductCategoryID { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid Rowguid { get; set; }
    public DateTime ModifiedDate { get; set; }

    public ICollection<ProductSubcategory> ProductSubcategories { get; set; } = new List<ProductSubcategory>();
}