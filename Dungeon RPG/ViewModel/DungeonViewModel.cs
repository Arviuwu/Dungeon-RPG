using Dungeon_RPG.MVVM;
using Dungeon_RPG.Model;
using Dungeon_RPG.Stores;
using Dungeon_RPG.Services;
namespace Dungeon_RPG.ViewModel
{
    public class DungeonViewModel
    {
        private readonly INavigationService _navigation;
        public CharacterStore CharacterStore { get; set; }
        public Enemy CurrentEnemy { get; set; }
        public Character CurrentCharacter { get; set; }
        public CharacterViewModel CharacterVM { get; set; }
        public EnemyViewModel EnemyVM { get; set; }
        public RelayCommand AttackCommand { get; }
        public RelayCommand ReturnCommand { get; }
        public bool TurnInProgress { get; set; }
        public DungeonViewModel(INavigationService navigation, CharacterStore characterStore)
        {
            _navigation = navigation;
            CharacterStore = characterStore;
            CurrentCharacter = CharacterStore.CurrentCharacter!;
            CharacterVM = new CharacterViewModel(CurrentCharacter);
            CurrentEnemy = new Enemy();
            EnemyVM = new EnemyViewModel(CurrentEnemy);

            TurnInProgress = false;
            

            

            AttackCommand = new RelayCommand(_ => attack(), _ => !TurnInProgress);
            ReturnCommand = new RelayCommand(_ => _navigation.NavigateTo(new PlayGameViewModel(_navigation, CharacterStore)), _ => EnemyVM.IsDead || CharacterVM.IsDead);
        }
        public async Task attack()
        {
            if (!TurnInProgress)
            {
                TurnInProgress = true;
                AttackCommand.RaiseCanExecuteChanged();// prevent attack button spamming
                CharacterVM.Attack(EnemyVM, this);
                await Task.Delay(1000);
                EnemyVM.Attack(CharacterVM, this);
                await Task.Delay(300);
                if (EnemyVM.IsDead)
                    return;
                TurnInProgress = false;
                AttackCommand.RaiseCanExecuteChanged();
            }
        }

        
    }
}
