using Dungeon_RPG.Model;
using Dungeon_RPG.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_RPG.ViewModel
{
    public class LocalizationViewModel : BaseViewModel
    {
        #region Localization
        public string CreateCharacter => LangHelper.GetString("UI_TXT_CreateCharacter");
        public string Items => LangHelper.GetString("UI_TXT_Items");
        public string Settings => LangHelper.GetString("UI_TXT_Settings");
        public string SaveFile => LangHelper.GetString("UI_TXT_SaveFile");
        public string Language => LangHelper.GetString("UI_TXT_Language");
        public string Play => LangHelper.GetString("UI_TXT_Play");
        public string Menu => LangHelper.GetString("UI_TXT_Menu");
        public string Strength => LangHelper.GetString("UI_TXT_Strength");
        public string Dexterity => LangHelper.GetString("UI_TXT_Dexterity");
        public string Constitution => LangHelper.GetString("UI_TXT_Constitution");
        public string Intelligence => LangHelper.GetString("UI_TXT_Intelligence");
        public string Wisdom => LangHelper.GetString("UI_TXT_Wisdom");
        public string Charisma => LangHelper.GetString("UI_TXT_Charisma");
        public string PointsRemaining => LangHelper.GetString("UI_TXT_PointsRemaining");
        public string Name => LangHelper.GetString("UI_TXT_Name");

        #endregion
        private void ToggleLanguage()
        {
            currentLanguage = currentLanguage == "en" ? "de" : "en";
            LangHelper.ChangeLanguage(currentLanguage);
            OnPropertyChanged(nameof(CreateCharacter));
            OnPropertyChanged(nameof(Items));
            OnPropertyChanged(nameof(Settings));
            OnPropertyChanged(nameof(SaveFile));
            OnPropertyChanged(nameof(Language));
            OnPropertyChanged(nameof(Play));
        }
        public RelayCommand ToggleLanguageCommand { get; }
        private string currentLanguage = "en";
        public LocalizationViewModel()
        {
            ToggleLanguageCommand = new RelayCommand(_ => ToggleLanguage());
        }
    }
}
