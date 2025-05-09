using Dungeon_RPG.ViewModel;
using System.Windows.Controls;

namespace Dungeon_RPG.View
{
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
            var vm = new MainMenuViewModel();
            DataContext = vm;
        }
    }
}
