using Dungeon_RPG.MVVM;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dungeon_RPG.Model
{
    public class Character :BaseViewModel
    {
        public string  Name { get; set; }
        public Stat CurrentHealth { get; set; } 
        public Stat MaxHealth { get; set; }
        public Stat BaseMana { get; set; }
        public Stat Strength { get; set; }
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
            Name = "Who are you?";
            Money = 0;
            RemainingStatpoints = 5;

            Strength = new Stat("Strength", 8);
            Dexterity = new Stat("Dexterity", 8);
            Constitution = new Stat("Constitution", 8);
            Intelligence = new Stat("Intelligence", 8);
            Wisdom = new Stat("Wisdom", 8);
            Charisma = new Stat("Charisma", 8);


            AllStats = new ObservableCollection<Stat>
            {
                Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma
            };
        }
    }
}
