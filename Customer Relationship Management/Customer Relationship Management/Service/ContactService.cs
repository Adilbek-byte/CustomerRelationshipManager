using Customer_Relationship_Management.Contracts.Contact;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Security.Cryptography.Xml;

namespace Customer_Relationship_Management.Service;

public class ContactService
{
    private readonly CustomerDbContext _context;
    private readonly IMapper _mapper;
    private readonly HttpContext _httContext;

    public ContactService(CustomerDbContext context, IMapper mapper, IHttpContextAccessor accessor)
    {
        _context = context;
        _mapper = mapper;
        if (accessor.HttpContext is null) throw new Exception(nameof(accessor.HttpContext));
        _httContext = accessor.HttpContext;
    }

    public Task<List<Contact>> GetContactsAsync() =>
        _context.Contacts.AsNoTracking().Include(x => x.User).ToListAsync();

    public async Task<List<Contact>> GetLeadsAsync() =>
      await _context.Contacts.Where(x => x.ContactStatus  == StatusEnum.Lead).ToListAsync();
        

    public async Task<ContactResponse> CreateContactAsync(ContactCreateRequest dto)
    {
        var user = await _context.Contacts.AsNoTracking().Include(x => x.User).FirstOrDefaultAsync(x => x.Email == dto.Email);
        if (user is null) throw new Exception("Error occurs");
        var newContact = _mapper.Map<Contact>(dto);
        newContact.UserId = int.Parse(_httContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        newContact.LastChangeContact = DateTime.UtcNow;
        await _context.Contacts.AddAsync(newContact);
        await _context.SaveChangesAsync();
        
        return _mapper.Map<ContactResponse>(newContact);
    }


    public async Task<ContactResponse> UpdateContactAsync(int id, ContactUpdateRequest dto)
    {
        var res = await _context.Contacts.AsNoTracking().Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
        if (res is null) return null!;
        res.FirstName = dto.FirstName;
        res.LastName = dto.LastName;
        res.MiddleName = dto.MiddleName;
        res.PhoneNumber = dto.PhoneNumber;
        res.Email = dto.Email;
        await _context.SaveChangesAsync();
        var contactGetDto = _mapper.Map<ContactResponse>(dto);
        return contactGetDto;
    }

    public async Task<ContactResponse> UpdateContactStatusAsync(int id, StatusEnum status)
    {
        var res = await _context.Contacts.FindAsync(id);
        if (res is null) return null!;
        res.ContactStatus = status;
        await _context.SaveChangesAsync();
        var getContactStatus = _mapper.Map<ContactResponse>(res);
        return getContactStatus;
    }

}
