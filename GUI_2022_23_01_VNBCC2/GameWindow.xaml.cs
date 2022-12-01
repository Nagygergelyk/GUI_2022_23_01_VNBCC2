using GUI_2022_23_01_VNBCC2.Logic;
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
using System.Windows.Shapes;

namespace GUI_2022_23_01_VNBCC2
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            InitializeComponent();
            GameLogic logic = new GameLogic();
            display.SetupModel(logic);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            display.Resize(new Size(game_grid.ActualWidth, game_grid.ActualHeight));
            display.InvalidateVisual();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            display.Resize(new Size(game_grid.ActualWidth, game_grid.ActualHeight));
            display.InvalidateVisual();
        }
    }
}
