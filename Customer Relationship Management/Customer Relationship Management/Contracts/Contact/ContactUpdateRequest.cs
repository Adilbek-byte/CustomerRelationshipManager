namespace Customer_Relationship_Management.Contracts.Contact;

public record ContactUpdateRequest
{
    public long? MarketerId { get; set; }

    [StringLength(200, ErrorMessage = Messages.String_length)]
    public string? FirstName { get; set; }

    [StringLength(200, ErrorMessage = Messages.String_length)]
    public string? LastName { get; set; }

    [StringLength(200, ErrorMessage = Messages.String_length)]
    public string? MiddleName { get; set; }

    
    public required string? PhoneNumber { get; set; }

    [StringLength(200, ErrorMessage = Messages.String_length)]
    [EmailAddress]
    public string? Email { get; set; }

    public StatusEnum? Status { get; set; }
}
