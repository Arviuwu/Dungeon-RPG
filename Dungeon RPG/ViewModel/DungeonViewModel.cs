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
        //public bool CanReturn { get; set; }
        public DungeonViewModel( INavigationService navigation, CharacterStore characterStore)
        {
            _navigation = navigation;
            CharacterStore = characterStore;
            CurrentCharacter = CharacterStore.CurrentCharacter!;
            CharacterVM = new CharacterViewModel(CurrentCharacter);
            CurrentEnemy = new Enemy();
            EnemyVM = new EnemyViewModel(CurrentEnemy);
            
            AttackCommand = new RelayCommand(_ => attack(EnemyVM));
            ReturnCommand = new RelayCommand(_ => _navigation.NavigateTo(new PlayGameViewModel(_navigation, CharacterStore)),_ => EnemyVM.IsDead);
        }
        public void attack(EnemyViewModel enemy)
        {
            CharacterVM.Attack(EnemyVM, this);
            enemy.attack
        }
    }
}
