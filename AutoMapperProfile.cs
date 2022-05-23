using AutoMapper;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Modals;

namespace dotnet_rpg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<Character,AddCharacterDto>();
            CreateMap<AddCharacterDto,Character>();
        }
    }
}