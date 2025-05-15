using Dungeon_RPG.Model;
using Dungeon_RPG.MVVM;
using System.Diagnostics;

namespace Dungeon_RPG.ViewModel
{
    public class StatViewModel : BaseViewModel
    {
        public Stat Stat { get; set; }

        public CharacterViewModel CharacterVM { get; set; }
        public EnemyViewModel EnemyVM { get; set; }

        public int Points
        {
            get { return Stat.Points; }
            set
            {
                if (Stat.Points != value)
                {
                    Stat.Points = value;
                    OnPropertyChanged();
                }
            }
        }
       
        public string Name
        {
            get { return Stat.Name; }
            set
            {
                if (Stat.Name != value)
                {
                    Stat.Name = value;
                    OnPropertyChanged();
                }

            }
        }
        public StatViewModel(Stat stat)
        { 
            Stat = stat;
        }
        public StatViewModel(Stat stat, CharacterViewModel characterVM)
        {
            CharacterVM = characterVM;
            Stat = stat;
            IncrementCommand = new RelayCommand(_ => IncPoints(),_ => CharacterVM.RemainingStatpoints > 0);
            DecrementCommand = new RelayCommand(_ => DecPoints(),_ => Points > 0);
        }
        public StatViewModel(Stat stat, EnemyViewModel enemyVM)
        {
            EnemyVM = enemyVM;
            Stat = stat;
            IncrementCommand = new RelayCommand(_ => IncPoints(), _ => EnemyVM.RemainingStatpoints > 0);
            DecrementCommand = new RelayCommand(_ => DecPoints(), _ => Points > 0);
        }
        public RelayCommand IncrementCommand { get; set; }
        public RelayCommand DecrementCommand { get; set; }
        private void IncPoints()
        {
            
                Points++;
                CharacterVM.RemainingStatpoints--;
                IncrementCommand.RaiseCanExecuteChanged();
                DecrementCommand.RaiseCanExecuteChanged();
        }
        private void DecPoints()
        {
            if (Points > 0)
            {
                Points--;
                CharacterVM.RemainingStatpoints++;
                IncrementCommand.RaiseCanExecuteChanged();
                DecrementCommand.RaiseCanExecuteChanged();
            }
        }
    }
}



