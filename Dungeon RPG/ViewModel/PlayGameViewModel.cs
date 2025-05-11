using Dungeon_RPG.Services;
using Dungeon_RPG.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_RPG.ViewModel
{
    public class PlayGameViewModel
    {
        private readonly INavigationService _navigation;
        public CharacterStore CharacterStore { get; set; }
        public PlayGameViewModel( INavigationService navigation, CharacterStore characterStore)
        {
            _navigation = navigation;
            CharacterStore = characterStore;
        }
    }
}
