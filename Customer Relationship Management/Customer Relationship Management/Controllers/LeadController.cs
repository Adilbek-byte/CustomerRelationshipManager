using Customer_Relationship_Management.Contracts.Lead;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Customer_Relationship_Management.Controllers;


[ApiController]
[Route("api/Lead")]
public class LeadController : ControllerBase
{
    private readonly LeadService _service;

    public LeadController(LeadService service)
    {
        _service = service;
    }

    [Authorize(Roles = UserRoles.Seller)]
    [HttpGet]
    public async Task<ActionResult<Lead>> GetMineLeads()
    {
        var res = await _service.GetAllLeadsAsync();
        return Ok();
    }

    [Authorize(Roles = UserRoles.Seller)]
    [HttpPost("{id}/post_lead")]
    public async Task<IActionResult> PostLead(LeadCreateDto dto)
    {
        var res = await _service.CreateLeadAsync(dto);
        if (res == null) return NotFound();
        return Ok();
    }

    [Authorize(Roles = UserRoles.Seller)]
    [HttpPut("{id}/edit_status")]
    public async Task<IActionResult> EditLeadStatus(int id, StatusEnum status)
    {
        var res = await _service.ChangeLeadStatusAsync(id, status);
        if (res == null) return BadRequest();
        return Ok();
    }

}
