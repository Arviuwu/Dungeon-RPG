using Dungeon_RPG.MVVM;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Windows.Input;

namespace Dungeon_RPG.Model
{
    public class Stat
    {
        public string Name { get; set; }
        public int Points { get;  set; }
        [JsonIgnore]
        public RelayCommand IncrementCommand { get; set; }
        [JsonIgnore]
        public RelayCommand DecrementCommand { get; set; }
        [JsonIgnore]
        public Action OnStatIncreased { get; set; }
        [JsonIgnore]
        public Action OnStatDecreased { get; set; }

        public Stat(string name, int points)
        {
            Name = name;
            Points = points;
        //    IncrementCommand = new RelayCommand(_ => IncPoints());
        //    DecrementCommand = new RelayCommand(_ => DecPoints());
        }

        //public void IncPoints()
        //{
        //    OnStatIncreased?.Invoke();
        //    Points++;
        //}

        //public void DecPoints()
        //{
        //    if (Points > 0)
        //    {
        //        Points--;
        //        OnStatDecreased?.Invoke();
        //    }
        //}
    }

}
