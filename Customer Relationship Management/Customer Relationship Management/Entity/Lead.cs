using Customer_Relationship_Management.Enums;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Customer_Relationship_Management.Entity;

public class Lead
{
    
    public required int Id { get; set; }

    
    public required int ContactId { get; set; }
    public int SaleId { get; set; }

    public List<Contact>? Contact { get; set; } = new();

    public User? Seller { get; set; }

    public required StatusEnum LeadStatus { get; set; }
}
