using API.Models;

namespace API.DTO;

public class BaseDTO<T> 
{
  public T Data { get; set; } = default!;
}

public class Products : BaseDTO<List<Product>> { }

public class ProductNamesAndPrices 
{
    public string Name { get; set; } = string.Empty;
    public decimal ListPrice { get; set; }
}

public class SalesOrdersGreatherThan150000
{
    public int SalesOrderID { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalDue { get; set; }
}

public class ProductByColor
{
    public string Color { get; set; } = string.Empty;
    public int TotalProducts { get; set; }
}

public class TotalSalesByYear
{
  public int Year { get; set; }
  public decimal TotalSales { get; set; }
}

public class ProductsByCategory
{
    public int? ProductSubcategoryID { get; set; }
    public int TotalProducts { get; set; }
}

public class AverageListPriceByCategory
{
    public string ProductCategory { get; set; } = string.Empty;
    public decimal AverageListPrice { get; set; }
} 

public class EmployeeOrderCount 
{
    public int BusinessEntityID { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int OrderCount { get; set; }
}

public class UnsoldProductsInLastYear
{
    public int ProductID { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class CustomersAndDetailsOfTheirOrders
{
    public int CustomerID { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int SalesOrderID { get; set; }
    public DateTime OrderDate { get; set; }
    public int ProductID { get; set; }
    public short OrderQty { get; set; }
}