using System.ComponentModel.DataAnnotations;

namespace Customer_Relationship_Management.Entity;

public class Sale
{
    public required int Id { get; set; }
    public required int LeadId { get; set; }
    public required int SellerId { get; set; }


    public List<Lead> Leads { get; set; } = new();
    public User? Seller { get; set; }


   
    public required DateTime ContractDate { get; set; }
    public required DateTime SaleDate { get; set; }

}
