using Dungeon_RPG.Model;
using Dungeon_RPG.MVVM;
using System;
using System.Collections.ObjectModel;

namespace Dungeon_RPG.ViewModel
{
    public class CharacterViewModel : BaseViewModel
    {
        public readonly Character Character;

        public CharacterViewModel(Character character)
        {
            Character = character;
        }

        public string Name
        {
            get => Character.Name;
            set
            {
                if (Character.Name != value)
                {
                    Character.Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public Stat BaseHealth
        {
            get => Character.BaseHealth;
            set
            {
                if (Character.BaseHealth != value)
                {
                    Character.BaseHealth = value;
                    OnPropertyChanged(nameof(BaseHealth));
                }
            }
        }

        public Stat Health
        {
            get => Character.Health;
            set
            {
                if (Character.Health != value)
                {
                    Character.Health = value;
                    OnPropertyChanged(nameof(Health));
                }
            }
        }

        public Stat BaseMana
        {
            get => Character.BaseMana;
            set
            {
                if (Character.BaseMana != value)
                {
                    Character.BaseMana = value;
                    OnPropertyChanged(nameof(BaseMana));
                }
            }
        }

        public Stat Strenght
        {
            get => Character.Strength;
            set
            {
                if (Character.Strength != value)
                {
                    Character.Strength = value;
                    OnPropertyChanged(nameof(Strenght));
                }
            }
        }

        public Stat Dexterity
        {
            get => Character.Dexterity;
            set
            {
                if (Character.Dexterity != value)
                {
                    Character.Dexterity = value;
                    OnPropertyChanged(nameof(Dexterity));
                }
            }
        }

        public Stat Constitution
        {
            get => Character.Constitution;
            set
            {
                if (Character.Constitution != value)
                {
                    Character.Constitution = value;
                    OnPropertyChanged(nameof(Constitution));
                }
            }
        }

        public Stat Intelligence
        {
            get => Character.Intelligence;
            set
            {
                if (Character.Intelligence != value)
                {
                    Character.Intelligence = value;
                    OnPropertyChanged(nameof(Intelligence));
                }
            }
        }

        public Stat Wisdom
        {
            get => Character.Wisdom;
            set
            {
                if (Character.Wisdom != value)
                {
                    Character.Wisdom = value;
                    OnPropertyChanged(nameof(Wisdom));
                }
            }
        }

        public Stat Charisma
        {
            get => Character.Charisma;
            set
            {
                if (Character.Charisma != value)
                {
                    Character.Charisma = value;
                    OnPropertyChanged(nameof(Charisma));
                }
            }
        }

        public decimal Money
        {
            get => Character.Money;
            set
            {
                if (Character.Money != value)
                {
                    Character.Money = value;
                    OnPropertyChanged(nameof(Money));
                }
            }
        }
        public int RemainingStatpoints
        {
            get => Character.RemainingStatpoints;
            set
            {
                if (Character.RemainingStatpoints != value)
                {
                    Character.RemainingStatpoints = value;
                    OnPropertyChanged(nameof(RemainingStatpoints));
                }
            }
        }
        
        public ObservableCollection<StatViewModel> AllStats { get; set; } = new();
    }
}
