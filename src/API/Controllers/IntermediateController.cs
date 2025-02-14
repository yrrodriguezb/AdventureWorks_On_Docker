using API.DTO;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class IntermediateController : ControllerBase
{
    private readonly IntermediateService _intermediateService;

    public IntermediateController(IntermediateService intermediateService)
    {
        _intermediateService = intermediateService;
    }


    [HttpGet]
    public IActionResult IntermediateQuery(int id)
    {
        BaseDTO<object> response = new();

        switch (id)
        {
            case 1:
                response.Data = _intermediateService.GetTotalSalesByYear();
                break;
            case 2:
                response.Data = _intermediateService.GetProductsByCategory();
                break;
            case 3:
                response.Data = _intermediateService.GetAverageListPriceByCategory();
                break;
            case 4:
                response.Data = _intermediateService.GetEmployeesWithMoreThanTenOrders();
                break;
            case 5:
                response.Data = _intermediateService.GetUnsoldProductsInLastYear();
                break;
            case 6:
                response.Data = _intermediateService.GetCustomersAndDetailsOfTheirOrders();
                break;
            default:
                return BadRequest("Invalid ID");
        }

        return Ok(response);
    }
}
