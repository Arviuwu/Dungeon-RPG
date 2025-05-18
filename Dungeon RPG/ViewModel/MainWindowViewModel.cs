using Dungeon_RPG.MVVM;
using Dungeon_RPG.Stores;
using Dungeon_RPG.Services;

namespace Dungeon_RPG.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private object currentView;

        public object CurrentView
        {
            get => currentView;
            set
            {
                if (currentView != value)
                {
                    currentView = value;
                    OnPropertyChanged();
                }
            }
        }
        public MainMenuViewModel MainMenuVM { get; }
        public CharacterCreatorViewModel CharacterCreatorVM { get; }

        public INavigationService NavigationService { get; }
        public CharacterStore CharacterStore { get; set; }
        public MainWindowViewModel(CharacterStore characterStore)
        {
            CharacterStore = characterStore;
            NavigationService = new NavigationService(this);

            MainMenuVM = new MainMenuViewModel(NavigationService, CharacterStore);
            CharacterCreatorVM = new CharacterCreatorViewModel(NavigationService, CharacterStore);
            CurrentView = MainMenuVM;
        }
        public void OpenPlay()
        {
            CurrentView = CharacterCreatorVM;
        }
    }
}
