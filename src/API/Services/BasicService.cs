using API.Context;
using API.DTO;
using API.Models;

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
        return  new();
    }

    public List<ProductNamesAndPrices> GetProductNamesAndPrices()
    {
        return  new();
    }

    public List<SalesOrdersGreatherThan150000> GetSalesOrdersGreatherThan150000()
    {
        return new();
    }

    public int GetTotalProducts()
    {
        return new();
    }

    public decimal GetTotalStandardCost()
    {
        return new();
    }

    public  decimal GetAverageListPrice()
    {
        return new();
    }

    public  decimal GetMaxListPrice()
    {
        return new();
    }

    public  decimal GetMinListPrice()
    {
        return new();
    }

    public List<ProductByColor> GetProductsByColor()
    {
        return new();
    }
}