using API.Context;
using API.DTO;

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
        return new BaseDTO<List<TotalSalesByYear>> { Data = new() };
    }

    // Agrupar por categoría de producto y contar los productos en cada categoría
    public BaseDTO<List<ProductsByCategory>> GetProductsByCategory()
    {
        return new BaseDTO<List<ProductsByCategory>> { Data = new() };
    }

    // Obtener el promedio de precio de lista de los productos por categoría
    public BaseDTO<List<AverageListPriceByCategory>> GetAverageListPriceByCategory()
    {
        return new BaseDTO<List<AverageListPriceByCategory>> { Data = new() };
    }

    // Encontrar los empleados que han realizado más de 10 órdenes de ventas
    public BaseDTO<List<EmployeeOrderCount>> GetEmployeesWithMoreThanTenOrders()
    {
        return new BaseDTO<List<EmployeeOrderCount>> { Data = new() };
    }

    public BaseDTO<List<UnsoldProductsInLastYear>> GetUnsoldProductsInLastYear()
    {
        return new BaseDTO<List<UnsoldProductsInLastYear>> { Data = new() };
    }

    // Obtener el nombre completo del cliente y los detalles de sus pedidos.
    public BaseDTO<List<CustomersAndDetailsOfTheirOrders>> GetCustomersAndDetailsOfTheirOrders()
    {
        return new BaseDTO<List<CustomersAndDetailsOfTheirOrders>> { Data = new() };
    }
}