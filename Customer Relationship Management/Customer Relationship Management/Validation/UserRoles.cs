namespace Customer_Relationship_Management.Validation;

public static class UserRoles
{
    public const string AdminAndMarketer = $"{Admin}, {Marketer}";
    public const string MarketerAndSeller = $"{Marketer}, {Seller}";
    public const string Seller = nameof(RoleEnum.Sales);
    public const string Marketer = nameof(RoleEnum.Marketing);
    public const string Admin = nameof(RoleEnum.Admin);
}
