using Dungeon_RPG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_RPG.Stores
{
    public class CharacterStore
    {
        public Character? CurrentCharacter { get; set; }
        public List<Character> AllCharacters { get; set; }
        public CharacterStore()
        {
            AllCharacters = new();
        }
        public Character CreateCharacter()
        {
            Character StoreCreatedcharacter = new();
            AllCharacters.Add(StoreCreatedcharacter);
            return StoreCreatedcharacter;
        }
    }
}
