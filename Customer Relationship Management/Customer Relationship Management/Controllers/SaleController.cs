using Customer_Relationship_Management.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;

namespace Customer_Relationship_Management.Controllers;

[ApiController]
[Route("api/sale")]
public class SaleController: ControllerBase
{
    private readonly SaleService _service;

    public SaleController(SaleService service)
    {
        _service = service;
    }

    [Authorize(Roles = UserRoles.Admin)]
    [HttpGet]
    public async Task<IActionResult> GetAllSales()
    {
        var result = await _service.GetAllAsync();

        return Ok(result);
    }

    [Authorize(Roles = UserRoles.Seller)]
    [HttpGet("seller")]
    public async Task<IActionResult> GetCurrentSellerSales()
    {
        var result = await _service.GetUserSalesAsync();

        return Ok(result);
    }


    [Authorize(Roles = UserRoles.Seller)]
    [HttpPost]
    public async Task<IActionResult> PostSale(int leadId)
    {   
        var result = await _service.CreateSaleAsync(leadId);
        if (result == null)
            return NotFound();
        return Ok(result);
    }
}
