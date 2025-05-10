using Dungeon_RPG.MVVM;
using Dungeon_RPG.Model;

namespace Dungeon_RPG.ViewModel
{
    public class CharacterCreatorViewModel : BaseViewModel
    {
        private readonly INavigationService _navigation;
        public RelayCommand GoToMenu { get; }
        public CharacterCreatorViewModel(INavigationService navigation)
        {
            Character Character = new();
            _navigation = navigation;
            GoToMenu = new RelayCommand(_ => _navigation.NavigateTo(new MainMenuViewModel(navigation)));
        }

    }
}
