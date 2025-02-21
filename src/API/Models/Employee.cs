namespace API.Models;

public class Employee
{
    public int BusinessEntityID { get; set; }
    public string NationalIDNumber { get; set; } = string.Empty;
    public string LoginID { get; set; } = string.Empty;
    public string? OrganizationNode { get; set; }
    public int OrganizationLevel { get; set; }
    public string JobTitle { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public char MaritalStatus { get; set; }
    public char Gender { get; set; }
    public DateTime HireDate { get; set; }
    public bool SalariedFlag { get; set; }
    public short VacationHours { get; set; }
    public short SickLeaveHours { get; set; }
    public bool CurrentFlag { get; set; }
    public Guid Rowguid { get; set; }
    public DateTime ModifiedDate { get; set; }

    public Person Person { get; set; } = null!;
}