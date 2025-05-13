using System.Windows.Controls;
using Dungeon_RPG.Model;
using Dungeon_RPG.ViewModel;

namespace Dungeon_RPG.View
{
    public partial class CharacterCreator : UserControl
    {
        public CharacterCreator()
        {
            InitializeComponent();
        }

        private void UserControl_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            double scaleX = e.NewSize.Width / AppProperties.Width;
            double scaleY = e.NewSize.Height / AppProperties.Height;

            double scale = Math.Min(scaleX, scaleY);

            MainScale.ScaleX = scale;
            MainScale.ScaleY = scale;
        }
    }
}
