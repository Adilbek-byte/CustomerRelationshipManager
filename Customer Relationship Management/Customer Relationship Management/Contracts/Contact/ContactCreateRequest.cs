namespace Customer_Relationship_Management.Contracts.Contact;

public record ContactCreateRequest
{
    [Required(AllowEmptyStrings = false,
        ErrorMessage = Messages.Required)]
    [StringLength(200, ErrorMessage = Messages.String_length)]
    public required string? FirstName { get; set; }

    [Required(AllowEmptyStrings = false,
        ErrorMessage = Messages.Required)]
    [StringLength(200, ErrorMessage = Messages.String_length)]
    public required string? LastName { get; set; }

    [Required(AllowEmptyStrings = false,
        ErrorMessage = Messages.Required)]
    [StringLength(200, ErrorMessage = Messages.String_length)]
    public string? MiddleName { get; set; }

    [Range(1, 1000, ErrorMessage = Messages.RangeOfNumbers)]
    [Required(ErrorMessage = Messages.Required)]
    public required long PhoneNumber { get; set; }



    [EmailAddress(ErrorMessage = Messages.Required)]
    public required string? Email { get; set; }

    [EnumDataType(typeof(StatusEnum), ErrorMessage = Messages.EnumFormat)]
    public StatusEnum ContactStatus { get; set; }

}
