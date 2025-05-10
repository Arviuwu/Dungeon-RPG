namespace Dungeon_RPG.Model
{
    class Character
    {
        public int BaseHealth { get; set; }
        public int Health { get; set; }
        public int BaseMana { get; set; }
        public int Strenght { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public decimal Money { get; set; }

        // public Weapon Selected weapon
        //Armor props
        //inventory props
        //stache

        public Character()
        {
            BaseHealth = 100;
            BaseMana = 100;
            Money = 0;
        }

    }
}
