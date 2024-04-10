namespace Customer_Relationship_Management.Contracts.User;

public record UserRegisterDto
{
    [StringLength(500, ErrorMessage = Messages.String_length)]
    [Required(AllowEmptyStrings = false, ErrorMessage = Messages.Required)]
    public string? FullName { get; set; }

    [EmailAddress]
    [StringLength(500, ErrorMessage = Messages.String_length)]
    public required string Email { get; set; }

    [StringLength(500, ErrorMessage = Messages.String_length)]
    public required string Password { get; set; }

    [EnumDataType(typeof(RoleEnum), ErrorMessage = Messages.EnumFormat)]
    public required RoleEnum Role { get; set; }
}

