namespace Customer_Relationship_Management.Contracts.Contact;

public record ContactEditStatusRequest
{
    public StatusEnum NewContactStatus { get; set; }
    public long ContactId { get; set; }
}
