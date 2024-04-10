using Customer_Relationship_Management.Contracts.User;

namespace Customer_Relationship_Management.Mappings;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<UserRegisterDto, User>().ReverseMap();
        CreateMap<User, UserRegisterReplyDto>().ReverseMap();
        CreateMap<User, UserReplyDto>().ReverseMap();
        CreateMap<User, LeadUserDto>().ReverseMap();

    }
}
