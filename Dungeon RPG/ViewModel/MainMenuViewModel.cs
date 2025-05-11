using Dungeon_RPG.Model;
using Dungeon_RPG.MVVM;
using Dungeon_RPG.Stores;
namespace Dungeon_RPG.ViewModel
{
    public class MainMenuViewModel : BaseViewModel
    {
        private readonly INavigationService _navigation;

        #region Localization
        public string CreateCharacter => LangHelper.GetString("UI_TXT_CreateCharacter");
        public string Items => LangHelper.GetString("UI_TXT_Items");
        public string Settings => LangHelper.GetString("UI_TXT_Settings");
        public string SaveFile => LangHelper.GetString("UI_TXT_SaveFile");
        public string Language => LangHelper.GetString("UI_TXT_Language");

        #endregion
        public RelayCommand ToggleLanguageCommand { get; }
        public RelayCommand GoToCreateCharacter { get; }
        private string currentLanguage = "en";
        public CharacterStore CharacterStore { get; set; }
        public MainMenuViewModel(INavigationService navigation, CharacterStore characterStore)
        {
            _navigation = navigation;
            ToggleLanguageCommand = new RelayCommand(_ => ToggleLanguage());
            GoToCreateCharacter = new RelayCommand(_ =>_navigation.NavigateTo( new CharacterCreatorViewModel(_navigation,characterStore)));
            CharacterStore = characterStore;
        }
        private void ToggleLanguage()
        {
            currentLanguage = currentLanguage == "en" ? "de" : "en";
            LangHelper.ChangeLanguage(currentLanguage);
            OnPropertyChanged(nameof(CreateCharacter));
            OnPropertyChanged(nameof(Items));
            OnPropertyChanged(nameof(Settings));
            OnPropertyChanged(nameof(SaveFile));
            OnPropertyChanged(nameof(Language));
        }

    } }
