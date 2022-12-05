using GUI_2022_23_01_VNBCC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_2022_23_01_VNBCC2.Services
{
    public class NewGameViaWindow : INewGameWindowService
    {
        public void CreateGame(ref Player[] players)
        {
            new NewGameWindow(ref players).ShowDialog();
        }
    }
}
