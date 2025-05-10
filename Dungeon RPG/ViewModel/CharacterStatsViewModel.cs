using Dungeon_RPG.Model;
using Dungeon_RPG.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_RPG.ViewModel
{
    public class CharacterStatsViewModel : BaseViewModel
    {
        public int RemainingPoints { get; set; }
        private Character character;

        public Character Character
        {
            get { return character; }
            set { character = value; 
                OnPropertyChanged(); }
        }

        public CharacterStatsViewModel()
        {
            RemainingPoints = 20;
            Character = new();
        }
    }
}
