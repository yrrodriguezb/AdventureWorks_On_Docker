using API.Context;
using API.DTO;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class IntermediateService
{
    private readonly AdventureWorksContext _context;

    public IntermediateService(AdventureWorksContext context)
    {
        _context = context;
    }

    // Obtener el total de ventas por año
    public BaseDTO<List<TotalSalesByYear>> GetTotalSalesByYear()
    {
        var query = 
        (
            from soh in _context.SalesOrderHeaders.AsNoTracking()
            group soh by soh.OrderDate.Year into g
            select new
            {
                Year = g.Key,
                TotalSales = g.Sum(soh => soh.TotalDue)
            } into result
            orderby result.Year
            select new TotalSalesByYear 
            {
                TotalSales = result.TotalSales,
                Year = result.Year
            }
        );

        return new BaseDTO<List<TotalSalesByYear>> { Data = query.ToList() };
    }

    // Agrupar por categoría de producto y contar los productos en cada categoría
    public BaseDTO<List<ProductsByCategory>> GetProductsByCategory()
    {
        var query = (
            from p in _context.Products.AsNoTracking()
            group p by p.ProductSubcategoryID into g
            select new ProductsByCategory
            {
                ProductSubcategoryID = g.Key,
                TotalProducts = g.Count()
            }
        );

        return new BaseDTO<List<ProductsByCategory>> { Data = query.ToList() };
    }

    // Obtener el promedio de precio de lista de los productos por categoría
    public BaseDTO<List<AverageListPriceByCategory>> GetAverageListPriceByCategory()
    {
        var query = (
            from p in _context.Products.AsNoTracking()
            join ps in _context.ProductSubcategories.AsNoTracking() on p.ProductSubcategoryID equals ps.ProductSubcategoryID
            join pc in _context.ProductCategories.AsNoTracking() on ps.ProductCategoryID equals pc.ProductCategoryID
            group new { p, pc } by pc.Name into g
            select new
            {
                CategoryName = g.Key,
                AverageListPrice = g.Average(ppc => ppc.p.ListPrice)
            } 
            into result
            orderby result.AverageListPrice descending
            select new AverageListPriceByCategory
            {
                ProductCategory = result.CategoryName,
                AverageListPrice = result.AverageListPrice
            }
        );

        return new BaseDTO<List<AverageListPriceByCategory>> { Data = query.ToList() };
    }

    // Encontrar los empleados que han realizado más de 10 órdenes de ventas
    public BaseDTO<List<EmployeeOrderCount>> GetEmployeesWithMoreThanTenOrders()
    {
        var query = (
            from soh in _context.SalesOrderHeaders.AsNoTracking()
            join sp in _context.SalesPersons.AsNoTracking() on soh.SalesPersonID equals sp.BusinessEntityID
            join e in _context.Employees.AsNoTracking() on sp.BusinessEntityID equals e.BusinessEntityID
            join p in _context.Persons.AsNoTracking() on e.BusinessEntityID equals p.BusinessEntityID
            group soh by new { e.BusinessEntityID, p.FirstName, p.LastName } into g
            where g.Count() > 10
            orderby g.Count() descending
            select new EmployeeOrderCount
            {
                BusinessEntityID = g.Key.BusinessEntityID,
                FirstName = g.Key.FirstName,
                LastName = g.Key.LastName,
                OrderCount = g.Count()
            }
        );

        return new BaseDTO<List<EmployeeOrderCount>> { Data = query.ToList() };
    }

    public BaseDTO<List<UnsoldProductsInLastYear>> GetUnsoldProductsInLastYear()
    {
        var oneYearAgo = DateTime.Now.AddYears(-1);

        var query = (
            from p in _context.Products.AsQueryable()
            join sod in _context.SalesOrderDetails.AsQueryable() on p.ProductID equals sod.ProductID into sodGroup
            from sod in sodGroup.DefaultIfEmpty()
            join soh in _context.SalesOrderHeaders.AsQueryable() on sod.SalesOrderID equals soh.SalesOrderID into sohGroup
            from soh in sohGroup.DefaultIfEmpty()
            where soh == null || soh.OrderDate < oneYearAgo
            orderby p.ProductID
            select new UnsoldProductsInLastYear
            {
                ProductID = p.ProductID,
                Name = p.Name
            }
        );

        return new BaseDTO<List<UnsoldProductsInLastYear>> { Data = query.ToList() };
    }

    // Obtener el nombre completo del cliente y los detalles de sus pedidos.
    public BaseDTO<List<CustomersAndDetailsOfTheirOrders>> GetCustomersAndDetailsOfTheirOrders()
    {
        var date = new DateTime(2014, 6, 30);

        var query = (
            from c in _context.Customers.AsNoTracking()
            join p in _context.Persons.AsNoTracking() on c.PersonID equals p.BusinessEntityID
            join soh in _context.SalesOrderHeaders.AsNoTracking() on c.CustomerID equals soh.CustomerID
            join sod in _context.SalesOrderDetails.AsNoTracking() on soh.SalesOrderID equals sod.SalesOrderID
            where soh.OrderDate >= date
            select new CustomersAndDetailsOfTheirOrders
            {
                CustomerID = c.CustomerID,
                FirstName =  p.FirstName,
                LastName = p.LastName,
                SalesOrderID =  soh.SalesOrderID,
                OrderDate = soh.OrderDate,
                ProductID = sod.ProductID,
                OrderQty = sod.OrderQty
            }
        );

        return new BaseDTO<List<CustomersAndDetailsOfTheirOrders>> { Data = query.ToList() };
    }
}