using GUI_2022_23_01_VNBCC2.Controller;
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
using System.Windows.Threading;

namespace GUI_2022_23_01_VNBCC2
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        GameController controller;
        DateTime startTime;

        public GameWindow(GameLogic logic)
        {
            InitializeComponent();
            startTime = DateTime.Now;
            //GameLogic logic = new GameLogic();
            display.SetupModel(logic);
            controller = new GameController(logic);

            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(1);
            dt.Tick += Dt_Tick;
            dt.Start();
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            this.time.Content = (DateTime.Now - startTime);
            display.InvalidateVisual();
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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            this.controller.PressedKey(e.Key);
            display.InvalidateVisual();
        }
    }
}
