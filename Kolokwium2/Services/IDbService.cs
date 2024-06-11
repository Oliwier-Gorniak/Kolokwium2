using Kolokwium2.DTOs;

namespace Kolokwium2.Services;

public interface IDbService
{
    Task<CharacterDTO> GetCharacterById(int characterId);
    Task<bool> DoItemsExist(List<int> itemIds);
}