using Kolokwium2.Data;
using Kolokwium2.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Services;

public class DbService : IDbService
{
    private readonly Kolos2Context _context;

    public DbService(Kolos2Context context)
    {
        _context = context;
    }

    public async Task<CharacterDTO> GetCharacterById(int characterId)
    {
        var character = await _context.Characters
            .Include(c => c.CharacterTitles)
            .ThenInclude(ct => ct.Title)
            .Include(c => c.Backpacks)
            .ThenInclude(b => b.Item)
            .FirstOrDefaultAsync(c => c.Id == characterId);
        
        var backpackItems = character.Backpacks.Select(b => new BackpackItemsDTO
        {
            ItemName = b.Item.Name,
            ItemWeight = b.Item.Weight,
            Amount = b.Amount
        }).ToList();
        var titles = character.CharacterTitles.Select(ct => new TitleDTO
        {
            Title = ct.Title.Name,
            AcquiredAt = ct.AcquiredAt
        }).ToList();
        return new CharacterDTO()
        {
            FirstName = character.FirstName,
            LastName = character.LastName,
            CurrentWeight = character.CurrentWeight,
            MaxWeight = character.MaxWeight,
            BackpackItems = backpackItems,
            Titles = titles
        };
    }

    public async Task<bool> DoItemsExist(List<int> itemIds)
    {
        return await _context.Items.AnyAsync(i => itemIds.Contains(i.Id));
    }
}