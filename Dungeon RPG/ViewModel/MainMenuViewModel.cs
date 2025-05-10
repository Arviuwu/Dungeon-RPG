using Dungeon_RPG.Model;
using Dungeon_RPG.MVVM;
namespace Dungeon_RPG.ViewModel
{
    public class MainMenuViewModel : BaseViewModel
    {
        private readonly INavigationService _navigation;

        #region Localization
        public string Play => LangHelper.GetString("UI_TXT_Play");
        public string Items => LangHelper.GetString("UI_TXT_Items");
        public string Settings => LangHelper.GetString("UI_TXT_Settings");
        public string SaveFile => LangHelper.GetString("UI_TXT_SaveFile");
        public string Language => LangHelper.GetString("UI_TXT_Language");

        #endregion
        public RelayCommand ToggleLanguageCommand { get; }
        public RelayCommand GoToPlay { get; }
        private string currentLanguage = "en";

        public MainMenuViewModel(INavigationService navigation)
        {
            _navigation = navigation;
            ToggleLanguageCommand = new RelayCommand(_ => ToggleLanguage());
            GoToPlay = new RelayCommand(_ =>_navigation.NavigateTo( new CharacterCreatorViewModel(_navigation)));
        }
        private void ToggleLanguage()
        {
            currentLanguage = currentLanguage == "en" ? "de" : "en";
            LangHelper.ChangeLanguage(currentLanguage);
            OnPropertyChanged(nameof(Play));
            OnPropertyChanged(nameof(Items));
            OnPropertyChanged(nameof(Settings));
            OnPropertyChanged(nameof(SaveFile));
            OnPropertyChanged(nameof(Language));
        }

    } }
