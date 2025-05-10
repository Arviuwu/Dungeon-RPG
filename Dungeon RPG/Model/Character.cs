using System.Collections.ObjectModel;

namespace Dungeon_RPG.Model
{
    public class Character
    {

        public Stat BaseHealth { get; set; } = new("Base Health", 100);
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
            BaseHealth = new("Base Health", 100);
            BaseMana = new("Base Mana", 100);
            Money = 0;

            AllStats.Add(Strenght = new Stat("Strength", 8));
            AllStats.Add(Dexterity = new Stat("Dexterity", 8));
            AllStats.Add(Constitution = new Stat("Constitution", 8));
            AllStats.Add(Intelligence = new Stat("Intelligence", 8));
            AllStats.Add(Wisdom = new Stat("Wisdom", 8));
            AllStats.Add(Charisma = new Stat("Charisma", 8));
        }

    }
}
