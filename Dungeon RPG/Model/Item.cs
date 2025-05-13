using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_RPG.Model
{
    public class Item
    {
        public string Name { get; set; }
        public Action<Character> Ability { get; set; }
        public string SpritePath { get; set; }
        public Item(string name, Action<Character> ability, string spritePath)
        {
            Name = name;
            Ability = ability;
            SpritePath = spritePath;
        }
    }
}
