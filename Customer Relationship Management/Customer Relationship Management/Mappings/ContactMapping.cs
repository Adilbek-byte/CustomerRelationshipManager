using Customer_Relationship_Management.Contracts.Contact;

namespace Customer_Relationship_Management.Mappings;

public class ContactMapping : Profile
{
    public ContactMapping()
    {
        CreateMap<Contact, ContactResponse>().ReverseMap();
        CreateMap<ContactCreateRequest, Contact>().ReverseMap();
        CreateMap<ContactUpdateRequest, Contact>().ReverseMap();


    }
}
