using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CharactersController : ControllerBase
{
    private readonly IDbService _dbService;

    public CharactersController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet("{characterId}")]
    public async Task<IActionResult> GetCharacterById(int characterId)
    {
        var character = await _dbService.GetCharacterById(characterId);
        return Ok(character);
    }

    [HttpPost("{characterId}/backpacks")]
    public async Task<IActionResult> AddItemsToCharacter(int characterId, List<int> itemIds)
    {
        if (!await _dbService.DoItemsExist(itemIds))
        {
            
        }
        return Created();
    }
}