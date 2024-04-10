using Customer_Relationship_Management.Contracts.Contact;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Customer_Relationship_Management.Controllers;

[Authorize]
[ApiController]
[Route("api/contact")]
public class ContactController : ControllerBase
{
    private readonly ContactService _Contact_service;

    public ContactController(ContactService Contact_service)
    {
        _Contact_service = Contact_service;
    }
    [Authorize(Roles = UserRoles.AdminAndMarketer)]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var res = await _Contact_service.GetContactsAsync() ?? throw new Exception("Not Found");
        return Ok(res);
    }

    [Authorize(Roles = UserRoles.Seller)]
    [HttpGet("LeadStatus")]
    public async Task<IActionResult> ViewContactByStatusLead()
    {
        var res = await _Contact_service.GetLeadsAsync();
        return Ok(res != null ? NoContent() : NotFound());

    }

    [Authorize(Roles = UserRoles.Marketer)]
    [HttpPost]
    public async Task<IActionResult> PostContact(ContactCreateRequest contactDto)
    {
        var res = await _Contact_service.CreateContactAsync(contactDto);
        return Created($"api/contacts/ {res.Id}", res);
    }

    [Authorize(Roles = UserRoles.MarketerAndSeller)]
    [HttpPut("{id}/update_contact")]
    public async Task<IActionResult> UpdateContact(int id, ContactUpdateRequest dto)
    {
        var res = await _Contact_service.UpdateContactAsync(id, dto);
        if (res == null) return NotFound();
        return Ok();
    }

    [Authorize(Roles = UserRoles.Marketer)]
    [HttpPut("{id}/update_status")]
    public async Task<IActionResult> UpdateContactStatus(int id, StatusEnum status)
    {
        var res = await _Contact_service.UpdateContactStatusAsync(id, status);
        if (res == null) return NotFound();
        return Ok();
    }
}




