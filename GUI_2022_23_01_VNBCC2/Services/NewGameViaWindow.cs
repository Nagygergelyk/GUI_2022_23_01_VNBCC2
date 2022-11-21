using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_2022_23_01_VNBCC2.Services
{
    internal class NewGameViaWindow : INewGameWindowService
    {
        public void CreateGame()
        {
            new NewGameWindow().ShowDialog();
        }
    }
}
