using Dungeon_RPG.Model;
using Dungeon_RPG.MVVM;
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

        public INavigationService NavigationService { get; }
        public MainWindowViewModel()
        {
            NavigationService = new NavigationService(this);
            MainMenuVM = new MainMenuViewModel(NavigationService);
            CharacterCreatorVM = new CharacterCreatorViewModel(NavigationService);
            CurrentView = MainMenuVM;
        }
        public void OpenPlay()
        {
            CurrentView = CharacterCreatorVM;
        }
    }
}
