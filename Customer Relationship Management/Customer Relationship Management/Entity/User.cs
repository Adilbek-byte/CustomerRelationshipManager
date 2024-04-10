using Customer_Relationship_Management.Enums;

namespace Customer_Relationship_Management.Entity;

public class User
{
    public required int Id { get; set; }

    public string? FullName { get; set; }
    public required string? Email { get; set; }
    public required string? Password { get; set; }

    public required RoleEnum Role { get; set; }

    public List<Contact> Contacts { get; set; } = new();
    public List<Sale> Sales { get; set; } = new();
    public List<Lead> Leads { get; set; } = new();
    public DateTime? DateBlock { get; set; }

}
