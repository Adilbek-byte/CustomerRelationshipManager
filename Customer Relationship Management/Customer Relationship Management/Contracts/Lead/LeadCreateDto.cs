namespace Customer_Relationship_Management.Contracts.Lead;

public record LeadCreateDto
{
    [Required(AllowEmptyStrings = false, ErrorMessage = Messages.Required)]
    public int ContactId { get; set; }

    [EnumDataType(typeof(LeadEnum), ErrorMessage = Messages.EnumFormat)]
    public LeadEnum Status { get; set; }
}
