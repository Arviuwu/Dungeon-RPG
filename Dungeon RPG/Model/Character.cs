using Dungeon_RPG.MVVM;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dungeon_RPG.Model
{
    public class Character :BaseViewModel
    {
        public string  Name { get; set; }
        public Stat BaseHealth { get; set; } 
        public Stat Health { get; set; }
        public Stat BaseMana { get; set; }
        public Stat Strenght { get; set; }
        public Stat Dexterity { get; set; }
        public Stat Constitution { get; set; }
        public Stat Intelligence { get; set; }
        public Stat Wisdom { get; set; }
        public Stat Charisma { get; set; }
        public decimal Money { get; set; }
        
        public int RemainingStatpoints { get; set; }
        
        
        public ObservableCollection<Stat> AllStats { get; set; } = new();

	

        // public Weapon Selected weapon
        //Armor props
        //inventory props
        //stache

        public Character()
        {
            BaseHealth = new("Base Health", 100, this);
            BaseMana = new("Base Mana", 100, this);
            Money = 0;
            RemainingStatpoints = 5;
            BaseHealth = new("Base Health", 100, this);
            Name = "Who are you?";
            AllStats.Add(Strenght = new Stat("Strength", 8, this));
            AllStats.Add(Dexterity = new Stat("Dexterity", 8, this));
            AllStats.Add(Constitution = new Stat("Constitution", 8, this));
            AllStats.Add(Intelligence = new Stat("Intelligence", 8, this));
            AllStats.Add(Wisdom = new Stat("Wisdom", 8, this));
            AllStats.Add(Charisma = new Stat("Charisma", 8, this));


        }
        
    }
}
