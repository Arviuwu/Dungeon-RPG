using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_RPG.Model
{
    public class Weapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public Action<Character> Ability { get; set; }
        public string SpritePath { get; set; }
        public Weapon(string name, int damage, string spritePath, Action<Character> ability = null)
        {
            Name = name;
            Damage = damage;
            Ability = ability;
            SpritePath = spritePath;
        }
    }
}

