using Dungeon_RPG.Model;
using Dungeon_RPG.MVVM;
namespace Dungeon_RPG.ViewModel
{
    public class MainMenuViewModel : BaseViewModel
    {
        #region Localization
        public string Play => LangHelper.GetString("UI_TXT_Play");
        public string Items => LangHelper.GetString("UI_TXT_Items");
        public string Settings => LangHelper.GetString("UI_TXT_Settings");
        public string SaveFile => LangHelper.GetString("UI_TXT_SaveFile");
        public string Language => LangHelper.GetString("UI_TXT_Language");
        
        #endregion
        public RelayCommand ToggleLanguageCommand { get; }
        private string currentLanguage = "en";
        private void ToggleLanguage()
        {
            currentLanguage = currentLanguage == "en" ? "de" : "en";
            LangHelper.ChangeLanguage(currentLanguage);
            OnPropertyChanged("Play");
            OnPropertyChanged("ITems");
            OnPropertyChanged("Settings");
            OnPropertyChanged("SaveFile");
            OnPropertyChanged("Language");
        }
        public MainMenuViewModel()
        {
            //LangHelper.ChangeLanguage("de");
            ToggleLanguageCommand = new RelayCommand(_ => ToggleLanguage());
        }

    }
}
