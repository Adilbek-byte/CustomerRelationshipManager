using Customer_Relationship_Management.Contracts.Lead;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Customer_Relationship_Management.Service;

public class LeadService
{
    private readonly CustomerDbContext _context;
    private readonly IMapper _mapper;
    private readonly HttpContext _httpContext;

    public LeadService(CustomerDbContext context, IMapper mapper, IHttpContextAccessor accesor)
    {
        _context = context;
        _mapper = mapper;
        if(accesor.HttpContext is null) throw new Exception(nameof(accesor.HttpContext));
        _httpContext = accesor.HttpContext;
    }

    public async Task<List<LeadResponse>> GetAllLeadsAsync()
    {
        var lead = await _context.Leads.AsNoTracking().Include(x => x.Contact)
             .Include(x => x.Seller)
             .ToListAsync();
        return _mapper.Map<List<LeadResponse>>(lead);
    }

    public async Task<List<LeadResponse>> CreateLeadAsync(LeadCreateDto requestDto)
    {
        var doesLeadExist = await _context.Leads.AsNoTracking().AnyAsync(lead => lead.ContactId == requestDto.ContactId);
        var doesContactExist = await _context.Contacts.AsNoTracking().AnyAsync(contact => contact.Id == requestDto.ContactId);
        if (!doesLeadExist) throw new Exception("there does not exist any Leads");
        if (!doesContactExist) throw new Exception("no such contact");
        var newLead = _mapper.Map<Lead>(requestDto);
        newLead.SaleId = int.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        await _context.Leads.AddAsync(newLead);
        await _context.SaveChangesAsync();
        var lead = await _context.Leads
            .AsNoTracking()
            .Include(lead => lead.Contact)
            .Include(lead => lead.Seller)
            .FirstOrDefaultAsync(lead => lead.ContactId == newLead.ContactId);
        return _mapper.Map<List<LeadResponse>>(lead);
    }

    public async Task<LeadResponse> ChangeLeadStatusAsync(long leadId, StatusEnum newStatus)
    {
        var lead = await _context.Leads
            .Include(lead => lead.Contact)
            .Include(lead => lead.Seller)
            .FirstOrDefaultAsync(lead => lead.ContactId == leadId);
        if (lead is null)
            return null!;

        lead.LeadStatus = newStatus;
        await _context.SaveChangesAsync();

        return _mapper.Map<LeadResponse>(lead);
    }
}
