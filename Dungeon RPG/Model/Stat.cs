using Dungeon_RPG.MVVM;
using System.Windows.Input;

namespace Dungeon_RPG.Model
{
    public class Stat : BaseViewModel
    {
        public string Name { get; set; }
        private int points;

        public int Points
        {
            get { return points; }
            set 
            { 
                points = value;
                OnPropertyChanged();
            }
        }

        public Stat(string name, int points)
        {
            Name = name;
            Points = points;
            IncrementCommand = new RelayCommand(_ => Points++);
            DecrementCommand = new RelayCommand(_ => Points--);
        }
        public RelayCommand IncrementCommand { get; set; }
        public RelayCommand DecrementCommand { get; set; }
        
    }
}
