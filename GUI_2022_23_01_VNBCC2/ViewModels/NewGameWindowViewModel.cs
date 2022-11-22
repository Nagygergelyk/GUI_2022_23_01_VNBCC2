using GUI_2022_23_01_VNBCC2.Logic;
using GUI_2022_23_01_VNBCC2.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI_2022_23_01_VNBCC2.ViewModels
{
    public class NewGameWindowViewModel : ObservableRecipient
    {
        public Player[] ActualPlayers { get; set; }

        public NewGameWindowViewModel()
        {
               
        }

        public void Setup(Player[] actualPlayers)
        {
            this.ActualPlayers = actualPlayers;
        }
    }
}
