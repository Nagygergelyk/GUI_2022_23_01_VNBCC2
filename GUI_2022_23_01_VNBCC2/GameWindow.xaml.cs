using GUI_2022_23_01_VNBCC2.Controller;
using GUI_2022_23_01_VNBCC2.Logic;
using GUI_2022_23_01_VNBCC2.ViewModels;
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
        TimeSpan actualTime;
        DispatcherTimer dt;

        public GameWindow(IGameLogic logic)
        {
            InitializeComponent();

            this.gwvm.SetUp(logic);
            display.SetupModel(logic as IGameModel);
            controller = new GameController(logic as IGameControl);

            startTime = DateTime.Now;
            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(1);
            dt.Tick += Dt_Tick;
            dt.Start();
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            actualTime = DateTime.Now - startTime;
            this.time_min.Content = (actualTime.Minutes);
            this.time_sec.Content = (actualTime.Seconds);
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
            if (e.Key == Key.Escape)
            {
                dt.Stop();

                GamePauseWindow1 gpw = new GamePauseWindow1();
                if (gpw.ShowDialog() == false)
                {
                    gpw.Close();
                    dt.Tick += Dt_Tick;
                    dt.Start();
                }
                else
                {
                    gpw.Close();
                    this.controller.PressedKey(Key.Escape);
                }
            }
            else
            {
                this.controller.PressedKey(e.Key);
            }          
            display.InvalidateVisual();
        }
    }
}
