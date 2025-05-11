using Dungeon_RPG.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_RPG.Services
{
    public class NavigationService : INavigationService
    {
        private readonly MainWindowViewModel _main;
        public NavigationService(MainWindowViewModel main)
        {
            _main = main;
        }
        public void NavigateTo(object viewModel)
        {
            _main.CurrentView = viewModel;
        }
    }
}
