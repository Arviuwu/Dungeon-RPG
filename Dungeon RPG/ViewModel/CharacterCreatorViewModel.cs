using Dungeon_RPG.MVVM;
using Dungeon_RPG.Model;
using Dungeon_RPG.Stores;

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
            GoToMenu = new RelayCommand(_ => _navigation.NavigateTo(new MainMenuViewModel(navigation, characterStore)));
        }
    }
}
