namespace API.Models;

public class UnitMeasure
{
    public string UnitMeasureCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<Product> SizeUnitMeasureProducts { get; set; } = new List<Product>();
    public virtual ICollection<Product> WeightUnitMeasureProducts { get; set; } = new List<Product>();
}