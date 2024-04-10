namespace Customer_Relationship_Management.Contracts.Lead;

public record LeadSaleResponse
{
    [Range(1, 10000, ErrorMessage = Messages.RangeOfNumbers)]
    public int ContactId { get; set; }

    public long? SellerId { get; set; }

    [EnumDataType(typeof(StatusEnum), ErrorMessage = Messages.EnumFormat)]
    public required StatusEnum Status { get; set; }
}
