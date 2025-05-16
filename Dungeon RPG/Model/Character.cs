using Dungeon_RPG.MVVM;
using Dungeon_RPG.ViewModel;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace Dungeon_RPG.Model
{
    public class Character :BaseViewModel
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public string SpritePath { get; set; }
        public Weapon HeldWeapon { get; set; }
        public Stat CurrentHealth { get; set; } 
        public Stat MaxHealth { get; set; }
        public Stat CurrentMana { get; set; }
        public Stat MaxMana { get; set; }
        public Stat Strength { get; set; }
        public Stat Dexterity { get; set; }
        public Stat Constitution { get; set; }
        public Stat Intelligence { get; set; }
        public Stat Wisdom { get; set; }
        public Stat Charisma { get; set; }
        public decimal Money { get; set; }
        public int RemainingStatpoints { get; set; }
        public ObservableCollection<Stat> AllStats { get; set; } = new();
        public int Level { get; set; }
        public int Exp { get; set; }


        
        //Armor props
        //inventory props
        //stache

        public Character()
        {
            Name = "Who are you?";
            Money = 0;
            RemainingStatpoints = 5;

            Strength = new Stat("Strength", 8);
            Dexterity = new Stat("Dexterity", 8);
            Constitution = new Stat("Constitution", 8);
            Intelligence = new Stat("Intelligence", 8);
            Wisdom = new Stat("Wisdom", 8);
            Charisma = new Stat("Charisma", 8);

            MaxHealth = new Stat("Max Health", 100+ 2*Constitution.Points);
            CurrentHealth = new Stat("Health", MaxHealth.Points);
            MaxMana = new Stat("Max Mana", 100+2*Intelligence.Points);
            CurrentMana = new Stat("Mana", MaxMana.Points);
            AllStats = new ObservableCollection<Stat>
            {
                Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma
            };
            Level = 1;
            HeldWeapon = new("Sword", 3, Path.Combine(AppContext.BaseDirectory, "Resources\\Sprites\\Swords\\Iicon_32_01.png"));
            SpritePath = Path.Combine(AppContext.BaseDirectory, "Resources\\Sprites\\Characters\\Knight.png");
            Id = Guid.NewGuid();
        }
    }
}
