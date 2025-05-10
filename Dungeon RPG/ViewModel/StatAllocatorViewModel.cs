using Dungeon_RPG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_RPG.ViewModel
{
    public class StatAllocatorViewModel
    {
        Stat Stat { get; set; }
        public StatAllocatorViewModel(Stat stat)
        {
            Stat = stat;
        }
    }
}
