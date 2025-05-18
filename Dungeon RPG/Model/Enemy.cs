using Dungeon_RPG.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_RPG.Model
{
    public class Enemy
    {
        public string Name { get; set; }
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
        public int ExpWorth { get; set; }
        public int RemainingStatpoints { get; set; }
        public bool IsDead { get; set; }

        public ObservableCollection<Stat> AllStats { get; set; } = new();

        
        public Enemy()
        {
            Name = "Slime";
            Money = 0;
            RemainingStatpoints = 5;

            Strength = new Stat("Strength", 8);
            Dexterity = new Stat("Dexterity", 8);
            Constitution = new Stat("Constitution", 8);
            Intelligence = new Stat("Intelligence", 8);
            Wisdom = new Stat("Wisdom", 8);
            Charisma = new Stat("Charisma", 8);
            CurrentHealth = new Stat("Health", 100);
            MaxHealth = new Stat("Max Health", 100);
            MaxMana = new Stat("Max Mana", 100);
            CurrentMana = new Stat("Mana", 100);
            AllStats = new ObservableCollection<Stat>
        {
            Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma
        };
            HeldWeapon = new("Sword", 3, Path.Combine(AppContext.BaseDirectory, "Resources\\Sprites\\Swords\\Iicon_32_01.png"));
            SpritePath = Path.Combine(AppContext.BaseDirectory, "Resources\\Sprites\\Characters\\Slime.png");
            ExpWorth = 50;
            IsDead = false;
        }
        public void Attack()
        {

        }
        }
    }


