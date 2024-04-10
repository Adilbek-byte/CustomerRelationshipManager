using Customer_Relationship_Management.Contracts.Sale;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Customer_Relationship_Management.Service;

public class SaleService
{
    private readonly CustomerDbContext _context;
    private readonly IMapper _mapper;
    private readonly HttpContext _httpContext;

    public SaleService(CustomerDbContext context, IMapper mapper, IHttpContextAccessor accessor)
    {
        _context = context;
        _mapper = mapper;
        if (accessor.HttpContext is null) throw new ArgumentException(nameof(accessor.HttpContext));
        _httpContext = accessor.HttpContext;
    }

    public async Task<List<SaleDto>> GetAllAsync()
    {
        var sales = await _context.Sales.AsNoTracking().Include(x => x.Leads).Include(x => x.Seller).ToListAsync();
        return _mapper.Map<List<SaleDto>>(sales);
    }

    public async Task<List<SaleDto>> GetUserSalesAsync()
    {
        var sellerId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var sales = await _context.Sales.AsNoTracking().Where(x => x.Seller!.Id == sellerId)
            .Include(x => x.Leads)
            .Include(x => x.Seller)
            .ToListAsync();
        return _mapper.Map<List<SaleDto>>(sales);
    }
    public async Task<List<SaleDto>> CreateSaleAsync(int leadId)
    {
        var lead = await _context.Leads.AsNoTracking().FirstOrDefaultAsync(lead => lead.ContactId == leadId);
        var currentSellerId = int.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        if (lead is null)
            return null!;

        var newSale = new Sale()
        {
            LeadId = leadId,
            SellerId = currentSellerId,
            ContractDate = DateTime.UtcNow,
            SaleDate = DateTime.UtcNow,
            Id = 0
        };

        await _context.Sales.AddAsync(newSale);
        await _context.SaveChangesAsync();
        var sale = await _context.Sales
            .AsNoTracking()
            .Include(sale => sale.Seller)
            .Include(sale => sale.Leads)
            .FirstOrDefaultAsync(sale => sale.Id == newSale.Id);

        return _mapper.Map<List<SaleDto>>(sale);
    }
}
