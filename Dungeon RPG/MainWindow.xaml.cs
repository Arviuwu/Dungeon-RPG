using Dungeon_RPG.Services;
using Dungeon_RPG.Stores;
using Dungeon_RPG.ViewModel;
using System.Windows;
namespace Dungeon_RPG
{
    public partial class MainWindow : Window
    {
        private SaveService SaveService;
        private CharacterStore CharStore;
        public MainWindow(CharacterStore charStore, SaveService saveService)
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(charStore);
            SaveService = saveService;
            CharStore = charStore;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveService.Save(CharStore);
        }
    }
}