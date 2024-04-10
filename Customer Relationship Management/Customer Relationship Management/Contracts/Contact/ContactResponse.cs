namespace Customer_Relationship_Management.Contracts.Contact;

public record ContactResponse
{
    [Range(1, 10000, ErrorMessage = Messages.RangeOfNumbers)]
    public required int Id { get; set; }

    public required string FirstName { get; set; }

    public required string? LastName { get; set; }

  

    public required string PhoneNumber { get; set; }

    public string? Email { get; set; }

    public required StatusEnum Status { get; set; }

    public required DateTime LastUpdated { get; set; }

}
