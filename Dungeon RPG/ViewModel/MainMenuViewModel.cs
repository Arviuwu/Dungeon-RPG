using Dungeon_RPG.Model;
using Dungeon_RPG.MVVM;
using Dungeon_RPG.Services;
using Dungeon_RPG.Stores;
using System.Windows;
namespace Dungeon_RPG.ViewModel
{
    public class MainMenuViewModel : BaseViewModel
    {
        private readonly INavigationService _navigation;


        private Character selectedCharacter;
        public Character SelectedCharacter
        {
            get
            {
                return selectedCharacter;
            }
            set
            {
                selectedCharacter = value;
                _CharacterStore.CurrentCharacter = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand GoToCreateCharacter { get; }
        public RelayCommand GoToPlayGame { get; }
        public CharacterStore _CharacterStore { get; set; }
        public MainMenuViewModel(INavigationService navigation, CharacterStore characterStore)
        {
            _navigation = navigation;
            
            GoToCreateCharacter = new RelayCommand(_ =>_navigation.NavigateTo( new CharacterCreatorViewModel(_navigation,characterStore)));
            GoToPlayGame = new RelayCommand(_ => PlayGameCheck(_navigation, _CharacterStore!));
            _CharacterStore = characterStore;
            if (_CharacterStore.LastCharacter != null)
            {
                SelectedCharacter = _CharacterStore.AllCharacters.Find(x => x.Id == _CharacterStore.LastCharacter.Id);
            }
        }
        public void PlayGameCheck(INavigationService _navigation,CharacterStore characterStore)
        {
            if(_CharacterStore.CurrentCharacter != null)
            {
                _CharacterStore.LastCharacter = _CharacterStore.CurrentCharacter;
                _navigation.NavigateTo(new PlayGameViewModel(_navigation, characterStore));
            }
            else
            {
                MessageBox.Show("Select a SaveFile");
            }
        }

    } }
