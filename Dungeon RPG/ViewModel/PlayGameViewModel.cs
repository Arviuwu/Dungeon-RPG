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
        public RelayCommand GoToPlay { get; }
        public RelayCommand GoToMenu { get; }
        public RelayCommand CharacterCommand { get; }
        public PlayGameViewModel( INavigationService navigation, CharacterStore characterStore)
        {
            _navigation = navigation;
            CharacterStore = characterStore;
            CharacterVM = new(CharacterStore.CurrentCharacter!);

            GoToPlay = new(_ => _navigation.NavigateTo(new DungeonViewModel(_navigation, CharacterStore)));
            GoToMenu = new(_ => _navigation.NavigateTo(new MainMenuViewModel(_navigation, CharacterStore)));
            CharacterCommand = new(_ => _navigation.NavigateTo(new CharacterEditorViewModel(_navigation, CharacterStore)));

        }
    }
}
