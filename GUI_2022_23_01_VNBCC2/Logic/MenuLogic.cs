using GUI_2022_23_01_VNBCC2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_2022_23_01_VNBCC2.Logic
{
    public class MenuLogic
    {
        INewGameWindowService newGameWindowService;

        public MenuLogic()
        {
        }

        public MenuLogic(INewGameWindowService newGameWindowService)
        {
            this.newGameWindowService = newGameWindowService;
        }

        public void NewGame()
        {
            newGameWindowService.CreateGame();
        }
    }
}
