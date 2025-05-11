using Dungeon_RPG.Model;
using Dungeon_RPG.MVVM;
using Dungeon_RPG.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_RPG.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private object currentView;

        public object CurrentView
        {
            get { return currentView; }
            set 
            { 
                currentView = value;
                OnPropertyChanged();
            }
        }
        public MainMenuViewModel MainMenuVM { get; }
        public CharacterCreatorViewModel CharacterCreatorVM { get; }
        public CharacterStatsViewModel CharacterStatsVM { get; }
        public INavigationService NavigationService { get; }
        public CharacterStore CharacterStore { get; set; }
        public MainWindowViewModel()
        {
            CharacterStore = new();

            NavigationService = new NavigationService(this);

            MainMenuVM = new MainMenuViewModel(NavigationService,CharacterStore);
            //CharacterCreatorVM = new CharacterCreatorViewModel(NavigationService, CharacterStore);
            CharacterStatsVM = new CharacterStatsViewModel(NavigationService);

            CurrentView = MainMenuVM;
        }
        public void OpenPlay()
        {
            CurrentView = CharacterCreatorVM;
        }
    }
}
