using Dungeon_RPG.MVVM;
using Dungeon_RPG.Services;
using Dungeon_RPG.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_RPG.ViewModel
{
    public class CharacterEditorViewModel
    {
        private readonly INavigationService _navigation;

        public CharacterStore CharacterStore { get; set; }
        public CharacterViewModel CharacterVM { get; }
        public RelayCommand BackCommand { get; }

        public CharacterEditorViewModel(INavigationService navigation, CharacterStore characterStore)
        {
            _navigation = navigation;
            CharacterStore = characterStore;
            CharacterVM = new(CharacterStore.CurrentCharacter!);

            BackCommand = new RelayCommand(_ => _navigation.NavigateTo(new PlayGameViewModel(_navigation, CharacterStore)));
        }
    }
}