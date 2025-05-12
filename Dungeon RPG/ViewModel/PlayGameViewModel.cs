using Dungeon_RPG.Model;
using Dungeon_RPG.MVVM;
using Dungeon_RPG.Services;
using Dungeon_RPG.Stores;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_RPG.ViewModel
{
    public class PlayGameViewModel : BaseViewModel
    {
        private readonly INavigationService _navigation;
        
        public CharacterStore CharacterStore { get; set; }
        public CharacterViewModel CharacterVM { get; }
        public PlayGameViewModel( INavigationService navigation, CharacterStore characterStore)
        {
            _navigation = navigation;
            CharacterStore = characterStore;
            CharacterVM = new(CharacterStore.CurrentCharacter!);
            foreach (Stat stat in CharacterStore.CurrentCharacter!.AllStats)
            {
                CharacterVM.AllStats.Add(new StatViewModel(stat, CharacterVM));
            }
            
        }
    }
}
