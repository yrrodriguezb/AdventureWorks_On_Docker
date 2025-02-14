using API.DTO;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class Basic : ControllerBase
{
    private readonly BasicService _basicService;

    public Basic(BasicService basicService)
    {
        _basicService = basicService;
    }


    [HttpGet]
    public IActionResult BasicQuery(int id)
    {
        BaseDTO<object> response = new();

        switch (id)
        {
            case 1:
                response.Data = _basicService.GetTop10Products();
                break;
            case 2:
                response.Data = _basicService.GetProductNamesAndPrices();
                break;
            case 3:
                response.Data = _basicService.GetSalesOrdersGreatherThan150000();
                break;
            case 4:
                response.Data = _basicService.GetTotalProducts();
                break;
            case 5:
                response.Data = _basicService.GetTotalStandardCost();
                break;
            case 6:
                response.Data = _basicService.GetAverageListPrice();
                break;
            case 7:
                response.Data = _basicService.GetMaxListPrice();
                break;
            case 8:
                response.Data = _basicService.GetMinListPrice();
                break;
            case 9:
                response.Data = _basicService.GetProductsByColor();
                break;
            default:
                return BadRequest("Invalid ID");
        }

        return Ok(response);
    }
}
