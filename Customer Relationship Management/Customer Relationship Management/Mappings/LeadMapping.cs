using Customer_Relationship_Management.Contracts.Lead;

namespace Customer_Relationship_Management.Mappings;

public class LeadMapping : Profile
{
    public LeadMapping()
    {
        CreateMap<Lead, LeadResponse>();
        CreateMap<Lead, LeadSaleResponse>();
        CreateMap<LeadCreateDto, Lead>();

    }
}
