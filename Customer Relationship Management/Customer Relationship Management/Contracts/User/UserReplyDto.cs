namespace Customer_Relationship_Management.Contracts.User;

public record UserReplyDto
{
    [Range(1, 10000, ErrorMessage = Messages.RangeOfNumbers)]
    public required int Id { get; set; }

    public string? FullName { get; set; }

    public required string Email { get; set; }

    [EnumDataType(typeof(RoleEnum), ErrorMessage = Messages.EnumFormat)]
    public required RoleEnum Role { get; set; }

    public DateTime? BlockDate { get; set; }
}
