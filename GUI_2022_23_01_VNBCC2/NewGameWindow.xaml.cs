using GUI_2022_23_01_VNBCC2.Models;
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
    /// Interaction logic for NewGameWindow.xaml
    /// </summary>
    public partial class NewGameWindow : Window
    {
        Player[] players;
        public Player[] Players { get; set; }

        public NewGameWindow(ref Player[] players)
        {
            InitializeComponent();
            this.players = players;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (cb_playerMode.IsChecked == true)
            {
                int i = 0;
                foreach (var item in s_playerNames.Children)
                {
                    if (item is TextBox t)
                    {
                        players[i] = new Player(t.Text);
                        i++;
                    }
                }
                this.DialogResult = true;
            }
            else
            {
                players[0] = new Player((s_playerNames.Children[1] as TextBox).Text);
                this.DialogResult = true;
            }
        }
    }
}
