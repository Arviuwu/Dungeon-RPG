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
            AllStats = new();
            CurrentHealthVM = new StatViewModel(Character.CurrentHealth, this);
            MaxHealthVM = new StatViewModel(Character.MaxHealth, this);
            MaxManaVM = new StatViewModel(Character.MaxMana, this);
            CurrentManaVM = new StatViewModel(Character.CurrentMana, this);
            AllStats.Add(StrengthVM = new StatViewModel(Character.Strength, this));
            AllStats.Add(DexterityVM = new StatViewModel(Character.Dexterity, this));
            AllStats.Add(ConstitutionVM = new StatViewModel(Character.Constitution, this));
            AllStats.Add(IntelligenceVM = new StatViewModel(Character.Intelligence, this));
            AllStats.Add(WisdomVM = new StatViewModel(Character.Wisdom, this));
            AllStats.Add(CharismaVM = new StatViewModel(Character.Charisma, this));
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

        public Guid Id
        {
            get => Character.Id;
            set
            {
                if (Character.Id != value)
                {
                    Character.Id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }
        public string SpritePath
        {
            get => Character.SpritePath;
            set
            {
                if (Character.SpritePath != value)
                {
                    Character.SpritePath = value;
                    OnPropertyChanged(nameof(SpritePath));
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

       
        public StatViewModel CurrentHealthVM { get; set; }
        public StatViewModel MaxHealthVM { get; set; }
        public StatViewModel MaxManaVM { get; set; }
        public StatViewModel CurrentManaVM { get; set; }
        public StatViewModel StrengthVM { get; set; }
        public StatViewModel DexterityVM { get; set; }
        public StatViewModel ConstitutionVM { get; set; }
        public StatViewModel IntelligenceVM { get; set; }
        public StatViewModel WisdomVM { get; set; }
        public StatViewModel CharismaVM { get; set; }

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

                    UpdateMaxHealth();
                    UpdateMaxMana();
                    foreach(StatViewModel s in AllStats)            // notifies statVM of added available points
                    {
                        s.IncrementCommand.RaiseCanExecuteChanged();
                    }

                    OnPropertyChanged(nameof(RemainingStatpoints));
                }
            }
        }
        public int Level
        {
            get => Character.Level;
            set
            {
                if (Character.Level != value)
                {
                    Character.Level = value;
                    UpdateMaxHealth();
                    UpdateMaxMana();
                    RemainingStatpoints++;
                    OnPropertyChanged(nameof(Money));
                }
            }
        }
        public int Exp
        {
            get => Character.Exp;
            set
            {
                if(value < 100)
                {
                    Character.Exp = value;
                }
                else
                {
                    Character.Exp = 0;
                    Level++;
                }

                    OnPropertyChanged(nameof(Money));
                
            }
        }
        public ObservableCollection<StatViewModel> AllStats { get; set; }

        public void Attack(EnemyViewModel enemyVM, DungeonViewModel d)
        {
            if(enemyVM.CurrentHealthVM.Points > 0)
            {
                var damage = HeldWeapon.Damage + StrengthVM.Points;
                enemyVM.TakeDamage(damage, this,d);
            }
            
        }
        public void UpdateMaxHealth()
        {
            MaxHealthVM.Points = 100 + ConstitutionVM.Points * 2 + Level * 2;
            CurrentHealthVM.Points = MaxHealthVM.Points;
        }
        public void UpdateMaxMana()
        {
            MaxManaVM.Points = 100 + IntelligenceVM.Points * 2 + Level * 2;
            CurrentManaVM.Points = MaxManaVM.Points;
        }
        public void GainExp(int exp)
        {
            Exp += exp;
        }
    }
}
