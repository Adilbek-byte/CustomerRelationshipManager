using Customer_Relationship_Management.Contracts.Contact;
using Customer_Relationship_Management.Contracts.User;

namespace Customer_Relationship_Management.Contracts.Lead;

public record LeadResponse
{
    public ContactResponse? Contact { get; set; }
    public LeadUserDto? Seller { get; set; }
    public required StatusEnum Status { get; set; }
}
