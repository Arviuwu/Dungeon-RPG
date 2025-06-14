using Dungeon_RPG.Model;
using Dungeon_RPG.MVVM;
using Dungeon_RPG.Services;
using Dungeon_RPG.Stores;
using Dungeon_RPG.ViewModel.Wrappers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_RPG.ViewModel
{
    public class PlayGameViewModel : BaseViewModel
    {
        private readonly INavigationService _navigation;
        
        public CharacterStore CharacterStore { get; set; }
        public CharacterViewModel CharacterVM { get; }
        public RelayCommand GoToPlay { get; }
        public RelayCommand GoToMenu { get; }
        public RelayCommand CharacterCommand { get; }
        public PlayGameViewModel( INavigationService navigation, CharacterStore characterStore)
        {
            _navigation = navigation;
            CharacterStore = characterStore;
            CharacterVM = new(CharacterStore.CurrentCharacter!);

            CharacterVM.IsDead = false;
            RegenHealth();
            RegenMana();

            GoToPlay = new(_ => _navigation.NavigateTo(new DungeonViewModel(_navigation, CharacterStore)));
            GoToMenu = new(_ => _navigation.NavigateTo(new MainMenuViewModel(_navigation, CharacterStore)));
            CharacterCommand = new(_ => _navigation.NavigateTo(new CharacterEditorViewModel(_navigation, CharacterStore)));

        }
        public async void RegenHealth()
        {
            if (CharacterVM.CurrentHealthVM.Points != CharacterVM.MaxHealthVM.Points)
            {
                do
                {
                    await Task.Delay(200);
                    int increment = (int)((double)CharacterVM.MaxHealthVM.Points * 0.05);
                    if (!(CharacterVM.CurrentHealthVM.Points + increment > CharacterVM.MaxHealthVM.Points))
                    {

                        CharacterVM.CurrentHealthVM.Points += increment;
                    }
                    else
                    {
                        CharacterVM.CurrentHealthVM.Points = CharacterVM.MaxHealthVM.Points;
                    }
                } while (CharacterVM.CurrentHealthVM.Points < CharacterVM.MaxHealthVM.Points);
            }
        }
        public async void RegenMana() // refactor, check for solution without first if
        {
            if (CharacterVM.CurrentManaVM.Points != CharacterVM.MaxManaVM.Points)
            {
                do
                {
                    await Task.Delay(200);
                    int increment = (int)(CharacterVM.MaxManaVM.Points * 0.05);
                    if (!(CharacterVM.CurrentManaVM.Points + increment > CharacterVM.MaxManaVM.Points))
                    {

                        CharacterVM.CurrentManaVM.Points += increment;
                    }
                    else
                    {
                        CharacterVM.CurrentManaVM.Points = CharacterVM.MaxManaVM.Points;
                    }
                } while (CharacterVM.CurrentManaVM.Points < CharacterVM.MaxManaVM.Points);
            }
        }
    }
}
