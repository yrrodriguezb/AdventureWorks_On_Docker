using API.Context;
using API.DTO;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services;


public class BasicService
{
    private readonly AdventureWorksContext _context;

    public BasicService(AdventureWorksContext context)
    {
        _context = context;
    }

    public List<Product> GetTop10Products()
    {
        return  _context.Products.Take(10).ToList();
    }

    public List<ProductNamesAndPrices> GetProductNamesAndPrices()
    {
        return  _context.Products
            .AsNoTracking()
            .Select(p => new ProductNamesAndPrices { Name = p.Name, ListPrice = p.ListPrice })
            .ToList();
    }

    public List<SalesOrdersGreatherThan150000> GetSalesOrdersGreatherThan150000()
    {
        return  _context.SalesOrderHeaders
            .AsNoTracking()
            .Where(s => s.TotalDue > 150000)
            .Select(s => new SalesOrdersGreatherThan150000
            {
                SalesOrderID = s.SalesOrderID,
                OrderDate = s.OrderDate,
                TotalDue = s.TotalDue
            })
            .OrderByDescending(s => s.OrderDate)
            .ToList();
    }

    public int GetTotalProducts()
    {
        return  _context.Products
            .AsNoTracking()
            .Count();
    }

    public decimal GetTotalStandardCost()
    {
        return _context.Products
            .AsNoTracking()
            .Sum(p => p.StandardCost);
    }

    public  decimal GetAverageListPrice()
    {
        return _context.Products
            .AsNoTracking()
            .Average(p => p.ListPrice);
    }

    public  decimal GetMaxListPrice()
    {
        return _context.Products
            .AsNoTracking()
            .Max(p => p.ListPrice);
    }

    public  decimal GetMinListPrice()
    {
        return _context.Products
            .AsNoTracking()
            .Min(p => p.ListPrice);
    }

    public List<ProductByColor> GetProductsByColor()
    {
        return _context.Products.AsNoTracking()
            .GroupBy(p => p.Color)
            .Where(g => g.Count(x => x.Color != null) > 0)
            .Select(g => new ProductByColor { Color = g.Key ?? string.Empty, TotalProducts = g.Count() })
            .OrderBy(x => x.TotalProducts)
            .ToList();
    }
}