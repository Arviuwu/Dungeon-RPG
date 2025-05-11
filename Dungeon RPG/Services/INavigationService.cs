using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_RPG.Services
{
    public interface INavigationService
    {
        void NavigateTo(object viewModel);
    }
}
