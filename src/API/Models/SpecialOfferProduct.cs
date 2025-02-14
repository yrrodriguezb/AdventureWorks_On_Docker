namespace API.Models;

public class SpecialOfferProduct
{
    public int SpecialOfferID { get; set; }
    public int ProductID { get; set; }
    public Guid Rowguid { get; set; }
    public DateTime ModifiedDate { get; set; }

    public Product Product { get; set; } = null!;
    public SpecialOffer SpecialOffer { get; set; } = null!;
}