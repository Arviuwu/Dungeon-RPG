using Dungeon_RPG.ViewModel;
using System.Windows;
namespace Dungeon_RPG
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext= new MainWindowViewModel();
            
        }
    }
}