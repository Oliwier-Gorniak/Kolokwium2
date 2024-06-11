using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Data;

public class Kolos2Context : DbContext
{
    protected Kolos2Context()
    {
    }

    public Kolos2Context(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Title> Titles { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Backpack> Backpacks { get; set; }
    public DbSet<CharacterTitle> CharacterTitles { get; set; }
    public DbSet<Character> Characters { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>().HasData(new List<Character>()
        {
            new Character
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                CurrentWeight = 100,
                MaxWeight = 200
            },
            new Character
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Davidson",
                CurrentWeight = 150,
                MaxWeight = 250
            }
        });

        modelBuilder.Entity<Item>().HasData(new List<Item>()
        {
            new Item()
            {
                Id = 1,
                Name = "Sword",
                Weight = 10
            },
            new Item()
            {
                Id = 2,
                Name = "Shield",
                Weight = 20
            },
            new Item()
            {
                Id = 3,
                Name = "Potion",
                Weight = 5
            }
        });
        
        modelBuilder.Entity<Title>().HasData(new List<Title>()
        {
            new Title()
            {
                Id = 1,
                Name = "Knight"
            },
            new Title()
            {
                Id = 2,
                Name = "Mage"
            },
            new Title()
            {
                Id = 3,
                Name = "Thief"
            }
        });

        modelBuilder.Entity<CharacterTitle>().HasData(new List<CharacterTitle>()
        {
            new CharacterTitle()
            {
                CharacterId = 1,
                TitleId = 1,
                AcquiredAt = DateTime.Parse("2021-06-01")
            },
            new CharacterTitle()
            {
                CharacterId = 1,
                TitleId = 2,
                AcquiredAt = DateTime.Parse("2024-06-02")
            },
            new CharacterTitle()
            {
                CharacterId = 2,
                TitleId = 3,
                AcquiredAt = DateTime.Parse("2022-06-03")
            },
            new CharacterTitle()
            {
                CharacterId = 1,
                TitleId = 3,
                AcquiredAt = DateTime.Parse("2023-08-04")
            }
        });

        modelBuilder.Entity<Backpack>().HasData(new List<Backpack>()
        {
            new Backpack()
            {
                CharacterId = 1,
                ItemId = 1,
                Amount = 1
            },
            new Backpack()
            {
                CharacterId = 2,
                ItemId = 3,
                Amount = 3
            },
            new Backpack()
            {
                CharacterId = 1,
                ItemId = 2,
                Amount = 1
            }
        });
    }
}