namespace Customer_Relationship_Management.Contracts.User;

public record UserLoginDto
{
    [StringLength(500, ErrorMessage = Messages.String_length)]
    public required string Email { get; set; }

    [StringLength(500, ErrorMessage = Messages.String_length)]
    public required string Password { get; set; }
}
