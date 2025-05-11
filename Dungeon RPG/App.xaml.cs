using Dungeon_RPG.Services;
using Dungeon_RPG.Stores;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Dungeon_RPG
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            CharacterStore c = new();
            SaveService SaveService = new();
            SaveService.Load(ref c);
            MainWindow = new MainWindow(c, SaveService);
            MainWindow.Show();
        }
    }

}
