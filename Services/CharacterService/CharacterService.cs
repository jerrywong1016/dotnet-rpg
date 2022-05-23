using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Modals;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {

        
        //async call is used to work with entity framework to make async call
        private static List<Character> characters = new List<Character>(){
            new Character(),
            new Character(){Id = 1, Name = "Sam"}
        };


        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var ServiceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id + 1); //make the id start from 1 instead of 0
            characters.Add(character);
            ServiceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return ServiceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
           var ServiceResponse = new ServiceResponse<List<GetCharacterDto>>();
           ServiceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
           return ServiceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
           var ServiceResponse = new ServiceResponse<GetCharacterDto>();
           ServiceResponse.Data = _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(Character => Character.Id == id));
           return ServiceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacterDto)
        {
            var ServiceResponse = new ServiceResponse<GetCharacterDto>();
            try{
                Character character = characters.FirstOrDefault(c => c.Id == updateCharacterDto.Id);
                character.Name = updateCharacterDto.Name;
                character.HitPoints = updateCharacterDto.HitPoints;
                character.Strength = updateCharacterDto.Strength;
                character.Defense = updateCharacterDto.Defense;
                character.Intelligence = updateCharacterDto.Intelligence;
                character.Class = updateCharacterDto.Class;
                ServiceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch(Exception ex){
                ServiceResponse.Success = false;
                ServiceResponse.Message = ex.Message;
            }
            // characters.Add(_mapper.Map<UpdateCharacterDto>(character));
            
            return ServiceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
           var ServiceResponse = new ServiceResponse<List<GetCharacterDto>>();
           try{
               Character character = characters.First(c => c.Id == id);
               characters.Remove(character);
               ServiceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
           }
           catch(Exception ex){
               ServiceResponse.Success = false;
               ServiceResponse.Message = ex.Message;
           }
           return ServiceResponse;
        }

    }
}