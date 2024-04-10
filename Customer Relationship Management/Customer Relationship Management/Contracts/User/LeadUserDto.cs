namespace Customer_Relationship_Management.Contracts.User;

public record LeadUserDto
{
    [Range(1, 1000, ErrorMessage = Messages.RangeOfNumbers)]

    public required int Id { get; set; }

    public string? FullName { get; set; }

    [EmailAddress]
    public required string Email { get; set; }

    [EnumDataType(typeof(RoleEnum), ErrorMessage = Messages.EnumFormat)]
    public required RoleEnum Role { get; set; }

    public DateTime? BlockDate { get; set; }
}
