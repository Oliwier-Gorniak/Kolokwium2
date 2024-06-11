namespace Kolokwium2.DTOs;

public class CharacterDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    public ICollection<BackpackItemsDTO> BackpackItems { get; set; } = null!;
    public ICollection<TitleDTO> Titles { get; set; } = null!;
}

public class BackpackItemsDTO
{
    public string ItemName { get; set; }
    public int ItemWeight { get; set; }
    public int Amount { get; set; }
}

public class TitleDTO
{
    public string Title { get; set; }
    public DateTime AcquiredAt { get; set; }
}