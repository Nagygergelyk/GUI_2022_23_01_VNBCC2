using GUI_2022_23_01_VNBCC2.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_2022_23_01_VNBCC2.ViewModels
{
    public class GameWindowViewModel
    {
        GameLogic logic;

        public GameWindowViewModel(GameLogic logic)
        {
            this.logic = logic;
        }

        public GameWindowViewModel() : this(new GameLogic(new MenuLogic()))
        {

        }
    }
}
