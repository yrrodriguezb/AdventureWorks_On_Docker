namespace API.Models;

public class Person
{
    public int BusinessEntityID { get; set; }
    public string PersonType { get; set; } = string.Empty;
    public bool NameStyle { get; set; }
    public string? Title { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string? Suffix { get; set; }
    public int EmailPromotion { get; set; }
    public string AdditionalContactInfo { get; set; } = string.Empty;
    public string Demographics { get; set; } = string.Empty;
    public Guid Rowguid { get; set; }
    public DateTime ModifiedDate { get; set; }

    public BusinessEntity BusinessEntity { get; set; } = null!;
    public ICollection<Customer> Customers { get; set; } = new List<Customer>();
}