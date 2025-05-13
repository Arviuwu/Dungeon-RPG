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
        public Weapon HeldWeapon
        {
            get => Character.HeldWeapon;
            set
            {
                if (Character.HeldWeapon != value)
                {
                    Character.HeldWeapon = value;
                    OnPropertyChanged(nameof(HeldWeapon));
                }
            }
        }
        public Stat MaxHealth
        {
            get => Character.MaxHealth;
            set
            {
                if (Character.MaxHealth != value)
                {
                    Character.MaxHealth = value;
                    OnPropertyChanged(nameof(MaxHealth));
                }
            }
        }

        public Stat CurrentHealth
        {
            get => Character.CurrentHealth;
            set
            {
                if (Character.CurrentHealth != value)
                {
                    Character.CurrentHealth = value;
                    OnPropertyChanged(nameof(CurrentHealth));
                }
            }
        }
        public Stat MaxMana
        {
            get => Character.MaxMana;
            set
            {
                if (Character.MaxMana != value)
                {
                    Character.MaxMana = value;
                    OnPropertyChanged(nameof(MaxMana));
                }
            }
        }
        public Stat CurrentMana
        {
            get => Character.CurrentMana;
            set
            {
                if (Character.CurrentMana != value)
                {
                    Character.CurrentMana = value;
                    OnPropertyChanged(nameof(CurrentMana));
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
