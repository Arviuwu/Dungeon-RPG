using Dungeon_RPG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dungeon_RPG.View
{
    /// <summary>
    /// Interaction logic for CharacterEditor.xaml
    /// </summary>
    public partial class CharacterEditor : UserControl
    {
        public CharacterEditor()
        {
            InitializeComponent();
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double scaleX = e.NewSize.Width / AppProperties.Width;
            double scaleY = e.NewSize.Height / AppProperties.Height;

            double scale = Math.Min(scaleX, scaleY);

            MainScale.ScaleX = scale;
            MainScale.ScaleY = scale;
        }
    }
}
