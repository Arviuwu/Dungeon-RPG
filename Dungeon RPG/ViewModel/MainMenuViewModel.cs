using Dungeon_RPG.Model;
using Dungeon_RPG.MVVM;
using Dungeon_RPG.Stores;
using System.Windows;
namespace Dungeon_RPG.ViewModel
{
    public class MainMenuViewModel : BaseViewModel
    {
        private readonly INavigationService _navigation;

       
        
        public RelayCommand GoToCreateCharacter { get; }
        public RelayCommand GoToPlayGame { get; }
        public CharacterStore CharacterStore { get; set; }
        public MainMenuViewModel(INavigationService navigation, CharacterStore characterStore)
        {
            _navigation = navigation;
            
            GoToCreateCharacter = new RelayCommand(_ =>_navigation.NavigateTo( new CharacterCreatorViewModel(_navigation,characterStore)));
            GoToPlayGame = new RelayCommand(_ => PlayGameCheck(_navigation, CharacterStore!));
            CharacterStore = characterStore;
        }
        public void PlayGameCheck(INavigationService _navigation,CharacterStore characterStore)
        {
            if(CharacterStore.CurrentCharacter != null)
            {
                _navigation.NavigateTo(new PlayGameViewModel(_navigation, characterStore));
            }
            else
            {
                MessageBox.Show("Select a SaveFile");
            }
        }

    } }
