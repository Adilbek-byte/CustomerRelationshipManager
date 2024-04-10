namespace Customer_Relationship_Management.Contracts.User;

public record UserRegisterReplyDto
{
    public required int Id { get; set; }

    
    public required string FullName { get; set; }

    public required string Email { get; set; }

    public required RoleEnum Role { get; set; }

    
}
