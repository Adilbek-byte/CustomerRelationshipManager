using Customer_Relationship_Management.Contracts.Lead;
using Customer_Relationship_Management.Contracts.User;

namespace Customer_Relationship_Management.Contracts.Sale;

public record SaleDto
{
    public required long Id { get; set; }
    public LeadSaleResponse? Lead { get; set; }
    public UserReplyDto? Seller { get; set; }
}
