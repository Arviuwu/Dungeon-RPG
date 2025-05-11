using Dungeon_RPG.MVVM;
using System.Diagnostics;
using System.Windows.Input;

namespace Dungeon_RPG.Model
{
    public class Stat 
    {
        public string Name { get; set; }
        private int points;

        public int Points
        {
            get { return points; }
            set 
            { 
                points = value;
               
            }
        }
        public Character LinkedChar  { get; set; }
        public Stat(string name, int points, Character linkedChar)
        {
            Name = name;
            Points = points;
            LinkedChar = linkedChar;
            IncrementCommand = new RelayCommand(_ => IncPoints());
            DecrementCommand = new RelayCommand(_ => DecPoints());
        }
        public RelayCommand IncrementCommand { get; set; }
        public RelayCommand DecrementCommand { get; set; }
        private void IncPoints()
        {
            if(LinkedChar.RemainingStatpoints > 0)
            {
                Points++;
                LinkedChar.RemainingStatpoints--;
                Debug.WriteLine("Stat inc");
            }
        }
        private void DecPoints()
        {
            if (Points > 0)
            {
                Points--;
                LinkedChar.RemainingStatpoints++;
                Debug.WriteLine("Stat dec");
            }
        }
    }
}
