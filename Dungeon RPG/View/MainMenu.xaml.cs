using Dungeon_RPG.Model;
using Dungeon_RPG.ViewModel;
using System.Windows.Controls;

namespace Dungeon_RPG.View
{
    public partial class MainMenu : UserControl
    {
        public MainMenu()
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
