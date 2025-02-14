namespace API.Models;

using System;

public class Product
{
    public int ProductID { get; set; }
    public string Name { get; set; } = null!;
    public string ProductNumber { get; set; } = null!;
    public bool? MakeFlag { get; set; }
    public bool? FinishedGoodsFlag { get; set; }
    public string? Color { get; set; }
    public short SafetyStockLevel { get; set; }
    public short ReorderPoint { get; set; }
    public decimal StandardCost { get; set; }
    public decimal ListPrice { get; set; }
    public string? Size { get; set; }
    public string? SizeUnitMeasureCode { get; set; }
    public string? WeightUnitMeasureCode { get; set; }
    public decimal? Weight { get; set; }
    public int DaysToManufacture { get; set; }
    public string? ProductLine { get; set; }
    public string? Class { get; set; }
    public string? Style { get; set; }
    public int? ProductSubcategoryID { get; set; }
    public int? ProductModelID { get; set; }
    public DateTime SellStartDate { get; set; }
    public DateTime? SellEndDate { get; set; }
    public DateTime? DiscontinuedDate { get; set; }
    public Guid Rowguid { get; set; }
    public DateTime ModifiedDate { get; set; }

    public virtual ProductSubcategory? ProductSubcategory { get; set; }
    public virtual ProductModel? ProductModel { get; set; }
    public virtual UnitMeasure? SizeUnitMeasure { get; set; }
    public virtual UnitMeasure? WeightUnitMeasure { get; set; }
    public virtual ICollection<SpecialOfferProduct> SpecialOfferProducts { get; set; } = null!;
    
}
