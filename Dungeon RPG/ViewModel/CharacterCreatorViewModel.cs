using Dungeon_RPG.MVVM;
using Dungeon_RPG.Model;
using Dungeon_RPG.Stores;
using Dungeon_RPG.Services;

namespace Dungeon_RPG.ViewModel
{
    public class CharacterCreatorViewModel : BaseViewModel
    {
        private CharacterStore characterStore;
        public CharacterStore CharacterStore
        {
            get
            {
                return characterStore;
            }
            set
            {
                characterStore = value;
                OnPropertyChanged(nameof(CharacterStore));
            }
        }
        public CharacterViewModel CharacterVM { get; }
        
        private readonly INavigationService _navigation;
        public RelayCommand GoToMenu { get; }
        public RelayCommand GoToPlay { get; }
        public CharacterCreatorViewModel(INavigationService navigation, CharacterStore characterStore)
        {
            this.CharacterStore = characterStore;


            this.CharacterStore.CurrentCharacter = CharacterStore.CreateCharacter();
            
            _navigation = navigation;

            CharacterVM = new(CharacterStore.CurrentCharacter);
            foreach(Stat stat in CharacterStore.CurrentCharacter.AllStats)
            {
                CharacterVM.AllStats.Add(new StatViewModel(stat, CharacterVM));
            }
            GoToMenu = new RelayCommand(_ => GoToMenuAndDeleteChar(_navigation, CharacterStore));
            GoToPlay = new RelayCommand(_ =>  GoToPlayCmd(_navigation, CharacterStore));
        }
        private void GoToMenuAndDeleteChar(INavigationService navigation, CharacterStore characterstore)
        {
            _navigation.NavigateTo(new MainMenuViewModel(navigation, characterstore));
            characterstore.AllCharacters.Remove(characterstore.CurrentCharacter!);
            characterstore.CurrentCharacter = null;
        }
        private void GoToPlayCmd(INavigationService navigation, CharacterStore _CharacterStore )
        {
            _navigation.NavigateTo(new PlayGameViewModel(_navigation, _CharacterStore));
            _CharacterStore.LastCharacter = _CharacterStore.CurrentCharacter;

        }
    }
}
