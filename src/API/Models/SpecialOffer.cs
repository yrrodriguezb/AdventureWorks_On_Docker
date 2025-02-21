namespace API.Models;

public class SpecialOffer
{
    public int SpecialOfferID { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal DiscountPct { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int MinQty { get; set; }
    public int? MaxQty { get; set; }
    public Guid Rowguid { get; set; }
    public DateTime ModifiedDate { get; set; }

    public ICollection<SpecialOfferProduct> SpecialOfferProducts { get; set; } = new List<SpecialOfferProduct>();
}