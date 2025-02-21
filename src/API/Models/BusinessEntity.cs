namespace API.Models;

public class BusinessEntity
{
    public int BusinessEntityID { get; set; }
    public Guid Rowguid { get; set; }
    public DateTime ModifiedDate { get; set; }

    public Person Person { get; set; } = null!;
}