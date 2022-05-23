using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Modals;
using dotnet_rpg.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;




namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        //we use di to inject IcharacterService to the controller
        public CharacterController(ICharacterService characterService)
        {
        
            _characterService = characterService;
        }
    // private static List<Character> characters = new List<Character>(){
    //         new Character(),
    //         new Character(){Id = 1, Name = "Sam"}
    //     };

    //we will initize this in the CharacterService (different service can use difference constructor)

    // [HttpGet] //for swagger get (usually Get() works)
    // [Route("GetAll")]
    
    //--------------------------------------------------------------------------------
    
    [HttpGet("GetAll")]
    public async Task<ActionResult<ServiceResponse<AddCharacterDto>>> Get()
    {
        return Ok(await _characterService.GetAllCharacters());
    }

    [HttpGet("{id}")] //only get the first one //route to the id name as the api endpoint
    public async Task<ActionResult<ServiceResponse<AddCharacterDto>>> GetSingle(int id)
    {
        return Ok(await _characterService.GetCharacterById(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<AddCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
    {
        return Ok( await _characterService.AddCharacter(newCharacter));
    }

    [HttpPut]
    public async Task<ActionResult<ServiceResponse<List<UpdateCharacterDto>>>> UpdateCharacter(UpdateCharacterDto newCharacter){
        var response = await _characterService.UpdateCharacter(newCharacter);
       if(response.Data == null){
           return NotFound(response); //need to be return NotFound(Response)
       }
        return Ok(await _characterService.UpdateCharacter(newCharacter));
    }

   [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> DeleteCharacter(int id){
        var response = await _characterService.DeleteCharacter(id);
        if(await _characterService.DeleteCharacter(id) == null){
           return NotFound(); //need to be return NotFound(Response)
       }
        return Ok(await _characterService.DeleteCharacter(id));
    }
}
}