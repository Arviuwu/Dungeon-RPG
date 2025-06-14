using Dungeon_RPG.Model;
using Dungeon_RPG.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dungeon_RPG.ViewModel.Wrappers
{
    public class EnemyViewModel : BaseViewModel
    {
        public readonly Enemy Enemy;

        public EnemyViewModel(Enemy enemy)
        {
            Enemy = enemy;

            MaxHealthVM = new(enemy.MaxHealth);
            CurrentHealthVM = new(enemy.CurrentHealth);
            MaxManaVM = new(enemy.MaxMana, this);
            CurrentManaVM = new(enemy.CurrentMana, this);
            StrengthVM = new(enemy.Strength, this);
            DexterityVM = new(enemy.Dexterity, this);
            ConstitutionVM = new(enemy.Constitution, this);
            IntelligenceVM = new(enemy.Intelligence, this);
            WisdomVM = new(enemy.Wisdom, this);
            CharismaVM = new(enemy.Charisma, this);

            AllStats = new ObservableCollection<StatViewModel>
        {
            MaxHealthVM,
            CurrentHealthVM,
            MaxManaVM,
            CurrentManaVM,
            StrengthVM,
            DexterityVM,
            ConstitutionVM,
            IntelligenceVM,
            WisdomVM,
            CharismaVM
        };
        }

        public string Name
        {
            get => Enemy.Name;
            set
            {
                if (Enemy.Name != value)
                {
                    Enemy.Name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string SpritePath
        {
            get => Enemy.SpritePath;
            set
            {
                if (Enemy.SpritePath != value)
                {
                    Enemy.SpritePath = value;
                    OnPropertyChanged();
                }
            }
        }

        public Weapon HeldWeapon
        {
            get => Enemy.HeldWeapon;
            set
            {
                if (Enemy.HeldWeapon != value)
                {
                    Enemy.HeldWeapon = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal Money
        {
            get => Enemy.Money;
            set
            {
                if (Enemy.Money != value)
                {
                    Enemy.Money = value;
                    OnPropertyChanged();
                }
            }
        }

        public int RemainingStatpoints
        {
            get => Enemy.RemainingStatpoints;
            set
            {
                if (Enemy.RemainingStatpoints != value)
                {
                    Enemy.RemainingStatpoints = value;
                    OnPropertyChanged();
                }
            }
        }
        public int ExpWorth
        {
            get => Enemy.ExpWorth;
            set
            {
                if (Enemy.ExpWorth != value)
                {
                    Enemy.ExpWorth = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsDead
        {
            get => Enemy.IsDead;
            set
            {
                if (Enemy.IsDead != value)
                {
                    Enemy.IsDead = value;
                    OnPropertyChanged();
                }
            }
        }

        
        public StatViewModel MaxHealthVM { get; }
        public StatViewModel CurrentHealthVM { get; }
        public StatViewModel MaxManaVM { get; }
        public StatViewModel CurrentManaVM { get; }
        public StatViewModel StrengthVM { get; }
        public StatViewModel DexterityVM { get; }
        public StatViewModel ConstitutionVM { get; }
        public StatViewModel IntelligenceVM { get; }
        public StatViewModel WisdomVM { get; }
        public StatViewModel CharismaVM { get; }

        public ObservableCollection<StatViewModel> AllStats { get; }
        public object CurrentHealth { get; internal set; }
        public void TakeDamage(int damage, CharacterViewModel c, DungeonViewModel d)
        {
            if (CurrentHealthVM.Points - damage <= 0 && !IsDead) //death
            {
                Die(c, d);
            }
            else
            {
                CurrentHealthVM.Points -= damage;
            }
        }
        public void Die(CharacterViewModel c, DungeonViewModel d)
        {

            c.GainExp(ExpWorth);
            CurrentHealthVM.Points = 0;
            IsDead = true;
            d.ReturnCommand.RaiseCanExecuteChanged();
        }
        public void Attack(CharacterViewModel c, DungeonViewModel d)
        {
            if (c.CurrentHealthVM.Points > 0 && !IsDead)
            {
                var damage = HeldWeapon.Damage + StrengthVM.Points;
                c.TakeDamage(damage,c,d);
            }
        }
    }
}



