namespace Customer_Relationship_Management.Contracts.User;

public record UserChangePasswordDto
{
    public required string OldPassword { get; set; }

    public required string NewPassword { get; set; }
}
