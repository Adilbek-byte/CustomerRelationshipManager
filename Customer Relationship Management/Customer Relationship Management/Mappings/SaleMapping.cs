using Customer_Relationship_Management.Contracts.Sale;

namespace Customer_Relationship_Management.Mappings;

public class SaleMapping : Profile
{
    public SaleMapping()
    {
        CreateMap<Sale, SaleDto>().ReverseMap();
    }
}
