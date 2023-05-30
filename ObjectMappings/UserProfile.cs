using AutoMapper;
using ObjectMappings.Models;

namespace ObjectMappings;

/// <summary>
/// Mapping Profile for User Class using AutoMapper
/// </summary>
public class UserProfile:Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();

        //Mapping with different Names
        CreateMap<User, UserDtoDifferentNames>()
                .ForMember(dest =>
                           dest.FName,
                           opt =>opt.MapFrom(src => src.FirstName));

        CreateMap<User, UserDtoDifferentNames>()
                .ForMember(dest =>
                        dest.LName,
                        opt => opt.MapFrom(src => src.LastName)).ReverseMap(); //ReverseMap to map bidirectional

        CreateMap<User, UserFullName>()
                    .ForMember(dest =>
                            dest.FullName,
                               opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
    }  
}
