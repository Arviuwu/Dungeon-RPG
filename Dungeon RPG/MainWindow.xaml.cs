using Dungeon_RPG.View;
using System.Windows;
namespace Dungeon_RPG
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainContent.Content = new MainMenu();
        }
    }
}